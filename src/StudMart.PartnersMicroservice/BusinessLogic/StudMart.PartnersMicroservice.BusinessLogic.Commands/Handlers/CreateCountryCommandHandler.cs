using AutoMapper;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Commands;
using StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers.Base;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Country;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Factories.Abstractions;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Repositories.Abstractions;
using SudMart.PartnersMicroservice.Domain.Factories.Implementations;

namespace StudMart.PartnersMicroservice.BusinessLogic.Commands.Handlers;

public class CreateCountryCommandHandler(
    INamedEntityRepository<Country, int, CountryName> repository,
    ICountryFactory factory,
    IMapper mapper)
    : CreateCommandHandler<CreateCountryCommand, CountryModel, CountryAddModel, Country, int, CountryFactory,
        CountryFactoryContract>(
        repository, factory, mapper)
{
    private readonly IMapper _mapper = mapper;

    public override async Task<CountryModel> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
       /* var find = await repository.GetByNameAsync(request.Model.Name, cancellationToken);
        if (find is not null)
            return _mapper.Map<Country, CountryModel>(find);*/
        return await base.Handle(request, cancellationToken);
    }
}