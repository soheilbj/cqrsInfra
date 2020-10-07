using MediatR;
using CQRSInfra.Application;
using CQRSInfra.Application.Configuration.Commands;
using CQRSInfra.Infrastructure.Processing.Outbox;

namespace CQRSInfra.Infrastructure.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}