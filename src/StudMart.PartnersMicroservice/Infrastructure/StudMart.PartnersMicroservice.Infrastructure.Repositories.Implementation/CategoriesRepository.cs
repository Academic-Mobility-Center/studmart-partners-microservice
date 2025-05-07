using Microsoft.EntityFrameworkCore;
using StudMart.PartnersMicroservice.Domain.Entities;
using StudMart.PartnersMicroservice.Domain.ValueObjects;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;
using StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation.Base;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.Infrastructure.Repositories.Implementation;

public class CategoriesRepository(DataContext context)
    : EfUpdatableDeletableRepositoryBase<Category, int>(context), ICategoriesRepository
{
    private readonly DataContext _context1 = context;

    public Task<Category?> GetByNameAsync(CategoryName name, CancellationToken cancellationToken = default) =>
        _context1.Categories.FirstOrDefaultAsync(category => category.Name == name, cancellationToken);
}