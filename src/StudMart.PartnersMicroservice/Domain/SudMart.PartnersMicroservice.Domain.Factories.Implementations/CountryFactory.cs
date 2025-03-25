using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace SudMart.PartnersMicroservice.Domain.Factories.Implementations;

public class CountryFactory : ICountryFactory
{
    public Task<Country> Create(CountryFactoryContract factoryContract)
    {
        return Task.FromResult(new Country(new CountryName(factoryContract.Name)));
    }
}