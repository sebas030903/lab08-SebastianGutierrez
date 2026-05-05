using lab08_SebastianGutierrez.Models;

namespace lab08_SebastianGutierrez.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsByPriceGreaterThanAsync(decimal price);

    Task<Product?> GetMostExpensiveProductAsync();

    Task<decimal> GetAveragePriceAsync();

    Task<List<Product>> GetProductsWithoutDescriptionAsync();
}