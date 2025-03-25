using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities.Base;
using StudMart.PartnersMicroservice.Domain.ValueObjects.Base;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;

public class EfNamedEntityRepository<TEntity, TId, TName>(DataContext context) : EfRepositoryBase<TEntity, TId>(context),
    INamedEntityRepository<TEntity, TId, TName> where TEntity : class, INamedEntity<TId, TName>
    where TId : struct
    where TName : INamedValueObject<string>
{
    private readonly DataContext _context = context;
    public Task<TEntity?> GetByNameAsync(TName name) => _context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Name.Equals(name));

}