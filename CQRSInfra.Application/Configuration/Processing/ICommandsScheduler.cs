using System.Threading.Tasks;
using MediatR;
using CQRSInfra.Application.Configuration.Commands;

namespace CQRSInfra.Application.Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);
    }
}