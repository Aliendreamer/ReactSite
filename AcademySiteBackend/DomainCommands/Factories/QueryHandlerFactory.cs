using System.Collections.Generic;
using AcademyData;
using AcademyModels;
using DomainUtility.Base;
using DomainUtility.Handlers;
using DomainUtility.Queries;

namespace DomainUtility.Factories
{
    public  class QueryHandlerFactory:IQueryHandlerFactory
    {
        private readonly AcademyDbContext _context;

        public QueryHandlerFactory(AcademyDbContext context)
        {
            _context = context;
        }
        public  IQueryHandler<AcademyUsersQuery, IEnumerable<AcademyUser>> Build(AcademyUsersQuery query)
        {
            return new AcademyUsersHandler(_context);
        }
    }

}
