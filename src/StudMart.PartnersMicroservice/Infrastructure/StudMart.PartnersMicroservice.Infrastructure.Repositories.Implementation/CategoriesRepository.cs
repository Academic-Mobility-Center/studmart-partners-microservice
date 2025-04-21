using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class CategoriesRepository(DataContext context) : EfNamedEntityRepositoryBase<Category, int, CategoryName>(context), ICategoriesRepository
{
    
}