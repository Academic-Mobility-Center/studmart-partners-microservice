using StudMart.PartnersMicroservice.Domain.Factories.Abstractions.Results;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts.Base;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions;

public interface IEntityFactory<in TContract> where TContract : IFactoryContract
{
    Task<IResult> Create(TContract contract, CancellationToken cancellationToken = default);
}