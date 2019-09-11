namespace DomainUtility.Base
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery
        : IQuery<TResponse>
    {
        TResponse ExecuteQuery();
    }
}