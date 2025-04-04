using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
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
    IMapper mapper)
    : CreateCommandHandlerBase<CreateCategoryCommand, CategoryModel, CategoryAddModel, Category, int, CategoryFactory,
        CategoryFactoryContract>(repository, factory, mapper)
{
}