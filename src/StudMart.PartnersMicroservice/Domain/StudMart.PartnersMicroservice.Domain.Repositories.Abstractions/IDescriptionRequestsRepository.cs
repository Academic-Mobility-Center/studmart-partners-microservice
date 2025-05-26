using StudMart.PartnersMicroservice.Domain.Entities;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IDescriptionRequestsRepository : IRepository<DescriptionRequest, Guid>, IUpdatableRepository<DescriptionRequest, Guid>
{
    
}