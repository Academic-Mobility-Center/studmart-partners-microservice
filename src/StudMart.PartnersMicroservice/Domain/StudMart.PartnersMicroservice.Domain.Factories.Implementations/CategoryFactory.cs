using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.Factories.Implementations.Results.Category;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class CategoryFactory(ICategoriesRepository categoriesRepository) : ICategoryFactory
{
    public async Task<IResult> Create(CategoryFactoryContract contract, CancellationToken cancellationToken = default)
    {
        var name = new CategoryName(contract.Name);
        var verification = await categoriesRepository.GetByNameAsync(name, cancellationToken);
        if (verification is not null)
            return new CategoryAlreadyExistsResult(verification);
        var category = new Category(name);
        return new CategoryCreatedResult(category);
    }
}