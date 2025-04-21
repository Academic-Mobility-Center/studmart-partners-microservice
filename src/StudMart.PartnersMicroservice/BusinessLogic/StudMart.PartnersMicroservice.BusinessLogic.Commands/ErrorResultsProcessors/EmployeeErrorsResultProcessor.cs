using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Employee;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;

public class EmployeeErrorsResultProcessor : IErrorsResultProcessor
{
    public IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult)
        => errorResult switch
        {
            PartnerNotFoundResult partnerNotFound => new Results.Employee.PartnerNotFoundResult(partnerNotFound.NotFoundId),
            EmailAlreadyRegisteredResult emailRegistered => new Results.Employee.EmailAlreadyRegisteredResult(emailRegistered.Email),
            _ => new InternalErrorResult()
        };
}