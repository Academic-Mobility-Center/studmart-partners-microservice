using AutoMapper;
using Microsoft.Extensions.Logging;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.ErrorResultsProcessors;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Results.Category;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Category;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateCategoryCommandHandler(
    ICategoriesRepository repository,
    ICategoryFactory factory,
    IMapper mapper, ILogger<CreateCategoryCommandHandler> logger)
    : CreateCommandHandlerBase<CreateCategoryCommand, CategoryModel, CategoryAddModel, Category, int, CategoryFactory,
        CategoryFactoryContract, CategoryCreatedResult>(repository, factory, mapper, new CategoryErrorResultProcessor(), logger)
{
}