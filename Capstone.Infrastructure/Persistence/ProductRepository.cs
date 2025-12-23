using Capstone.Application.Common.Interfaces.Persistence;
using Capstone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Infrastructure.Persistence;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product[]> GetProducts()
    {
        return await _context.Products.ToArrayAsync();
    } 
}