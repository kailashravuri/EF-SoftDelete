using System.Threading.Tasks;

namespace EntityFramework.Ententions.SoftDelte.Poc.Interface
{
    public interface ICommandHandler<in T>
    {
        Task HandleAsync(T input);
    }
}
