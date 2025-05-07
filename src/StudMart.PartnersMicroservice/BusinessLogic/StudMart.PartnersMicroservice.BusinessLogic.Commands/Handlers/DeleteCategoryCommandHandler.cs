using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class DeleteCategoryCommandHandler(
    ICategoriesRepository categoriesRepository,
    ILogger<DeleteCategoryCommandHandler> logger) : IRequestHandler<DeleteCategoryCommand, IResult>
{
    public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoriesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
        {
            logger.LogWarning("Category with Id {RequestId} was not found", request.Id);
            return new CategoryNotFoundResult(request.Id);
        }
        var result = await categoriesRepository.DeleteAsync(category, cancellationToken);
        return result ? new CategoryDeletedResult() : new InternalErrorResult();
    }
}