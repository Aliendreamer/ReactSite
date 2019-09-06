namespace AcademySiteBackend
{
	using System.Threading.Tasks;
	using Helpers;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;
	using System.Text;
	using AcademyData;
	using AcademyDomain.Helpers;
	using AcademyModels;
	using AutoMapper;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;
	using Swashbuckle.AspNetCore.Swagger;
	using Constants = AcademyDomain.Helpers.Constants;

	public class Startup
	{
		private static string connectionString;

		public Startup(IConfiguration configuration)
		{
			connectionString = Configuration.GetConnectionString("DefaultConnection");
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.UseAllOfType<IService>();

			services
				.UseRegisterDbContext(connectionString)
				.UseOneTransactionPerHttpCall()
				.UseMigrations(connectionString); //Sets up IMigrationContext

			var identityBuilder = services.AddIdentityCore<AcademyUser>(o =>
			{
				// configure identity options
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = false;
				o.Password.RequireUppercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 3;
			});

			identityBuilder =
				new IdentityBuilder(identityBuilder.UserType, typeof(AcademyRole), identityBuilder.Services);
			identityBuilder.AddEntityFrameworkStores<AcademyDbContext>().AddDefaultTokenProviders();

			// Register the ConfigurationBuilder instance of AuthSettings
			var authSettings = Configuration.GetSection(nameof(AuthSettings));
			services.Configure<AuthSettings>(authSettings);

			var signingKey =
				new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings[nameof(AuthSettings.SecretKey)]));

			// jwt wire up
			// Get options from app settings
			var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

			// Configure JwtIssuerOptions
			services.Configure<JwtIssuerOptions>(options =>
			{
				options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
				options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
				options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
			});

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
				ValidateAudience = true,
				ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				RequireExpirationTime = false,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(configureOptions =>
			{
				configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
				configureOptions.TokenValidationParameters = tokenValidationParameters;
				configureOptions.SaveToken = true;

				configureOptions.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						{
							context.Response.Headers.Add("Token-Expired", "true");
						}

						return Task.CompletedTask;
					}
				};
			});

			services.AddAuthorization(options =>
				options.AddPolicy("AcademyUser", policy =>
					policy.RequireClaim(Constants.JwtClaimIdentifiers.Rol,
						Constants.JwtClaims.ApiAccess)));

			services.AddAutoMapper(typeof(Startup));

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "AcademySite API",
					Description = "Enforcing AcademySite backend endpoints",
					TermsOfService = "should be something meaningful",
					Contact = new Contact
					{
						Name = "should be added",
						Email = " ",
						Url = "should be something meaningful",
					},
					License = new License
					{
						Name = "Use under LICX",
						Url = "should be something meaningful",
					}
				});
				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
				//Swagger 2.+ support
				c.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					In = "header",
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = "apiKey"
				});

				c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					{"Bearer", new string[] { }}
				});
			});
			services.AddMvc(x => { x.Filters.AddService<TransactionFilter>(1); })
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				//app.UseHsts();
			}
			app.UseStaticFiles();

			//app.UseHttpsRedirection();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("swagger/v1/swagger.json", "AcademySite");
				c.RoutePrefix = string.Empty;
			});

			app.UseAuthentication();

			app.UseMvc();
		}
	}
}