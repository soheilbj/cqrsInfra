using System;
using MediatR;
using Newtonsoft.Json;
using CQRSInfra.Application.Configuration.Commands;
using CQRSInfra.Domain.Customers;

namespace CQRSInfra.Application.Customers
{
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, CustomerId customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public CustomerId CustomerId { get; }
    }
}