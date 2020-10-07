﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CQRSInfra.Application.Configuration;

namespace CQRSInfra.API.Configuration
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid CorrelationId
        {
            get
            {
                if (IsAvailable && _httpContextAccessor.HttpContext.Request.Headers.Keys.Any(x => x == CorrelationMiddleware.CorrelationHeaderKey))
                {
                    return Guid.Parse(
                        _httpContextAccessor.HttpContext.Request.Headers[CorrelationMiddleware.CorrelationHeaderKey]);
                }
                throw new ApplicationException("Http context is not available");
            }
        }

        public bool IsAvailable => _httpContextAccessor.HttpContext != null;
    }
}