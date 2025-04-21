using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;

namespace StudMart.PartnersMicroservice.Repositories.Abstractions;

public interface ICategoriesRepository : INamedEntityRepository<Category, int, CategoryName>
{
    
}