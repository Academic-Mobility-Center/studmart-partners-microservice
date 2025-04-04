using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class CategoryFactory : ICategoryFactory
{
    public Task<Category> Create(CategoryFactoryContract contract) =>
        Task.FromResult(new Category(new CategoryName(contract.Name)));
}