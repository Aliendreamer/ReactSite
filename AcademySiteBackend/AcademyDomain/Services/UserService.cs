using AcademyData;

namespace AcademyDomain.Services
{
	public class UserService : BaseService
	{
		public UserService(AcademyDbContext context)
			: base(context)
		{
		}
	}
}