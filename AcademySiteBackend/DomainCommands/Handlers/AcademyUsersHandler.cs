using System.Collections.Generic;
using AcademyData;
using AcademyModels;
using DomainUtility.Base;
using DomainUtility.Queries;

namespace DomainUtility.Handlers
{
    public class AcademyUsersHandler :BaseQueryHandler<AcademyUsersQuery,IEnumerable<AcademyUser>>
    {
        public AcademyUsersHandler(AcademyDbContext context) 
            : base(context)
        {
        }

        public override IEnumerable<AcademyUser> ExecuteQuery()
        {
            return Context.Set<AcademyUser>();
        }
    }
}
