using System;
using MediatR;
using Newtonsoft.Json;
using CQRSInfra.Application.Configuration.Commands;
using CQRSInfra.Domain.Payments;

namespace CQRSInfra.Application.Payments.SendEmailAfterPayment
{
    public class SendEmailAfterPaymentCommand : InternalCommandBase<Unit>
    {
        public PaymentId PaymentId { get; }

        [JsonConstructor]
        public SendEmailAfterPaymentCommand(Guid id, PaymentId paymentId) : base(id)
        {
            this.PaymentId = paymentId;
        }
    }
}