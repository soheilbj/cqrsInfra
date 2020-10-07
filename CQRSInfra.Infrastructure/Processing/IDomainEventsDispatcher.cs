using System.Threading.Tasks;

namespace CQRSInfra.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}