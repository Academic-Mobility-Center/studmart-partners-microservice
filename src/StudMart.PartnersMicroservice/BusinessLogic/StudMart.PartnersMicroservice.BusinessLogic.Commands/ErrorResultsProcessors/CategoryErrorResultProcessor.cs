using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Category;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;

public class CategoryErrorResultProcessor : IErrorsResultProcessor
{
    public IErrorResult ProcessErrorResult(Domain.Factories.Abstractions.Results.IErrorResult errorResult)
        => errorResult switch
        {
            CategoryAlreadyExistsResult categoryAlreadyExists => new Results.Category.CategoryAlreadyExistsResult(categoryAlreadyExists.Entity.Name.Name),
            _ => new InternalErrorResult()

        };
}