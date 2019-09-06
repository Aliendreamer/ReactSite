namespace AcademySiteBackend.Helpers
{
	using System;
	using System.Data;
	using System.Data.Common;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Reflection;
	using AcademyData;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;

	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection UseAllOfType<T>(this IServiceCollection serviceCollection, ServiceLifetime lifetime = ServiceLifetime.Scoped)
		{
			return serviceCollection.UseAllOfType<T>(new[] { typeof(ServiceCollectionExtensions).Assembly });
		}

		public static IServiceCollection UseAllOfType<T>(this IServiceCollection serviceCollection, Assembly[] assemblies, ServiceLifetime lifetime = ServiceLifetime.Scoped)
		{
			var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(T))));
			foreach (var type in typesFromAssemblies)
				serviceCollection.Add(new ServiceDescriptor(type, type, lifetime));

			return serviceCollection;
		}

		public static IServiceCollection UseRegisterDbContext(this IServiceCollection serviceCollection, string connectionString, IsolationLevel level = IsolationLevel.ReadUncommitted)
		{
			//First, configure the SqlConnection and open it
			//This is done for every request/response
			serviceCollection.AddScoped<DbConnection>((serviceProvider) =>
			{
				var dbConnection = new SqlConnection(connectionString);
				dbConnection.Open();
				return dbConnection;
			});

			//Start a new transaction based on the SqlConnection
			//This is done for every request/response
			serviceCollection.AddScoped<DbTransaction>((serviceProvider) =>
			{
				var dbConnection = serviceProvider
					.GetService<DbConnection>();

				return dbConnection.BeginTransaction(level);
			});

			//Create DbOptions for the DbContext, use the DbConnection
			//This is done for every request/response
			serviceCollection.AddScoped<DbContextOptions>((serviceProvider) =>
			{
				var dbConnection = serviceProvider.GetService<DbConnection>();
				return new DbContextOptionsBuilder<AcademyDbContext>()
					.UseSqlServer(dbConnection)
					.Options;
			});

			//Finally, create the DbContext, using the transaction
			//This is done for every request/response
			serviceCollection.AddScoped((serviceProvider) =>
			{
				var transaction = serviceProvider.GetService<DbTransaction>();
				var options = serviceProvider.GetService<DbContextOptions>();
				var context = new AcademyDbContext(options);
				context.Database.UseTransaction(transaction);
				return context;
			});

			return serviceCollection;
		}

		public static IServiceCollection UseOneTransactionPerHttpCall(this IServiceCollection serviceCollection)
		{
			//Manage the transaction at level of HTTP request/response
			//This is done for every request/response
			serviceCollection.AddScoped(typeof(TransactionFilter), typeof(TransactionFilter));

			return serviceCollection;
		}

		public static IServiceCollection UseMigrations(this IServiceCollection serviceCollection, string connectionString)
		{
			serviceCollection.AddScoped<IMigrationContext>((serviceProvider) =>
			{
				var ctxOptions = new DbContextOptionsBuilder<AcademyDbContext>()
					.UseSqlServer(connectionString)
					.Options;

				var context = new AcademyDbContext(ctxOptions);
				return context;
			});

			return serviceCollection;
		}

		public static IApplicationBuilder MigrateDatabaseUponAppStart(this IApplicationBuilder app, ILogger logger)
		{
			logger.LogTrace("MigrateDatabaseUponAppStart");

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var migrationContext = serviceScope.ServiceProvider.GetRequiredService<IMigrationContext>();
				var applicationDbContext = migrationContext as AcademyDbContext; //This will always be correct, since we registered it in the method above
				var applicationDb = applicationDbContext?.Database;
				applicationDb?.SetCommandTimeout(TimeSpan.FromMinutes(5));
				applicationDb?.Migrate();
			}

			logger.LogTrace("MigrateDatabaseUponAppStart suceeded");

			return app;
		}
	}
}