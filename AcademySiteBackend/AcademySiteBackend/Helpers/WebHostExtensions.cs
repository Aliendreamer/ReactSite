namespace AcademySiteBackend.Helpers
{
	using System.IO;
	using AcademyData;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;

	public static class WebHostExtensions
	{
		public static IWebHost UpgradeRegisterDb(this IWebHost webHost)
		{
			var connectionString = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build().GetConnectionString("DefaultConnection");

			var options = new DbContextOptionsBuilder<AcademyDbContext>()
				.UseSqlServer(connectionString)
				.Options;

			var dbContext = new AcademyDbContext(options);
			dbContext.Database.Migrate();

			return webHost;
		}
	}
}