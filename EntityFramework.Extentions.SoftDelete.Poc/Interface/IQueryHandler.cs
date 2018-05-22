namespace EntityFramework.Extentions.SoftDelete.Poc.Interface
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
