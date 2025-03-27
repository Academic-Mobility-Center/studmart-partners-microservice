using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IPartnersRepository : IUpdatableRepository<Partner, Guid>, IDeletableRepository<Partner, Guid>
{
    
}