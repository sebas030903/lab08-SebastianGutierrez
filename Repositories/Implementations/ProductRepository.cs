using lab08_SebastianGutierrez.Data;
using lab08_SebastianGutierrez.Models;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab08_SebastianGutierrez.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsByPriceGreaterThanAsync(decimal price)
    {
        return await _context.Products
            .Where(p => p.Price > price)
            .ToListAsync();
    }

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);
    }

    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
}