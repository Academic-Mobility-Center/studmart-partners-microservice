using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;

public interface IErrorsResultProcessor
{
    IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult);
}