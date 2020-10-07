using MediatR;
using CQRSInfra.Application;
using CQRSInfra.Application.Configuration.Commands;

namespace CQRSInfra.Infrastructure.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}