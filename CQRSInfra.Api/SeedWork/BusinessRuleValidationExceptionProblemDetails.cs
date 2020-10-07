using Microsoft.AspNetCore.Http;
using CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.API.SeedWork
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            this.Title = "Business rule validation error";
            this.Status = StatusCodes.Status409Conflict;
            this.Detail = exception.Details;
            this.Type = "https://sbijavardomain/rulevalidationpage.html";
        }
    }
}