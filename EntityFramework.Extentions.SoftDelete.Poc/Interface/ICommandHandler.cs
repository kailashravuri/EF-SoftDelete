using System.Threading.Tasks;

namespace EntityFramework.Extentions.SoftDelete.Poc.Interface
{
    public interface ICommandHandler<in T>
    {
        Task HandleAsync(T input);
    }
}
