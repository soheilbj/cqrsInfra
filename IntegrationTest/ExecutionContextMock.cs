using System;
using CQRSInfra.Application.Configuration;

namespace CQRSInfra.IntegrationTests.SeedWork
{
    public class ExecutionContextMock : IExecutionContextAccessor
    {
        public Guid CorrelationId { get; set; }

        public bool IsAvailable { get; set; }
    }
}