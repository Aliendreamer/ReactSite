using AcademyData;

namespace DomainUtility.Base
{
    public abstract class BaseQueryHandler<TQuery,TResponse> : IQueryHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        protected AcademyDbContext Context { get; }

        protected BaseQueryHandler(AcademyDbContext context)
        {
            Context = context;
        }
        public abstract TResponse ExecuteQuery();
    }
}
