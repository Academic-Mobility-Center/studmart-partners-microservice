using System.Text.Json;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Partner;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class UpdateCategoryCommandHandler(
    ICategoriesRepository categories,
    IMapper mapper,
    ILogger<UpdateCategoryCommandHandler> logger) : IRequestHandler<UpdateCategoryCommand, IResult>
{
    public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(JsonSerializer.Serialize(request.Model));
        var category = await categories.GetByIdAsync(request.Model.Id, cancellationToken);
        if (category is null)
        {
            logger.LogWarning("Category with id {ModelId} was not found", request.Model.Id);
            return new CategoryNotFoundResult(request.Model.Id);
        }

        var name = new CategoryName(request.Model.Name);
        var verification = await categories.GetByNameAsync(name, cancellationToken);
        if (verification is not null && verification.Id != request.Model.Id)
        {
            logger.LogWarning("Category with name {ModelName} already exists", request.Model.Name);
            return new CategoryAlreadyExistsResult(request.Model.Name);
        }

        category.Name = name;
        category.Priority = new Priority(request.Model.Priority);
        var result = await categories.UpdateAsync(category, cancellationToken);
        if (result)
            return new CategoryUpdatedResult(mapper.Map<CategoryModel>(category));
        return new InternalErrorResult();
    }
}