using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Employee;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;

public class DescriptionRequestErrorsResultProcessor : IErrorsResultProcessor
{
    public IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult) =>
        errorResult switch
        {
            Domain.Factories.Implementations.Results.DescriptionRequest.EmployeeNotFoundResult notFoundResult => new EmployeeNotFoundResult(notFoundResult.NotFoundId),
            _ => new InternalErrorResult()
        };
}