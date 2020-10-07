using System.Threading;
using System.Threading.Tasks;

namespace CQRSInfra.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}