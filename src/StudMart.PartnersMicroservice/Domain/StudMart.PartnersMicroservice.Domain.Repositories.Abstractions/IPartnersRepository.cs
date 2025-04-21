using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.Entities.Aggregates;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface IPartnersRepository : IUpdatableRepository<Partner, Guid>, IDeletableRepository<Partner, Guid>, IEmailEntityRepository<Partner, Guid>, INamedEntityRepository<Partner, Guid, CompanyName>
{
    Task<Partner?> GetByInnAsync(long inn, CancellationToken cancellationToken);
    Task<Partner?> GetByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);
}