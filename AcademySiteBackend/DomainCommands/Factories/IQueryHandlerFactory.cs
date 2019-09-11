using System.Collections.Generic;
using AcademyModels;
using DomainUtility.Base;
using DomainUtility.Queries;

namespace DomainUtility.Factories
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<AcademyUsersQuery, IEnumerable<AcademyUser>> Build(AcademyUsersQuery query);
    }
}
