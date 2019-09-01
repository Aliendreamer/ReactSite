using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AcademySiteBackend
{
	using Helpers;

	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args)
				.Build()
				// Make sure our database exists and is migrated
				//.UpgradeRegisterDb()
				.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}