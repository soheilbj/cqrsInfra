using System;
using System.Threading.Tasks;

namespace CQRSInfra.Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
