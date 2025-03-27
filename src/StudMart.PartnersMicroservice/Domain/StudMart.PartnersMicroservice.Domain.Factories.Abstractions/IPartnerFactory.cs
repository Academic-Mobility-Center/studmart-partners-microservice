using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.Factories.Contracts;

namespace StudMart.PartnersMicroservice.Domain.Factories.Abstractions;

public interface IPartnerFactory : IEntityFactory<Partner, Guid, PartnerFactoryContract>
{
    
}