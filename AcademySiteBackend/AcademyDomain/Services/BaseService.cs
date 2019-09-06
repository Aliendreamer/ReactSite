namespace AcademyDomain.Services
{
	using AcademyData;
	using Interfaces;

	public abstract class BaseService : IService
	{
		private readonly AcademyDbContext context;

		protected BaseService(AcademyDbContext context)
		{
			this.context = context;
		}
	}
}