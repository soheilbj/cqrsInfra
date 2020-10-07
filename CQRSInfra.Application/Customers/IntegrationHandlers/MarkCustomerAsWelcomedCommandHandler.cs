using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CQRSInfra.Application.Configuration.Commands;
using CQRSInfra.Domain.Customers.Orders;

namespace CQRSInfra.Application.Customers.IntegrationHandlers
{
    public class MarkCustomerAsWelcomedCommandHandler : ICommandHandler<MarkCustomerAsWelcomedCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public MarkCustomerAsWelcomedCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(MarkCustomerAsWelcomedCommand command, CancellationToken cancellationToken)
        {
            var customer = await this._customerRepository.GetByIdAsync(command.CustomerId);

            customer.MarkAsWelcomedByEmail();

            return Unit.Value;
        }
    }
}