using lab08_SebastianGutierrez.DTOs.Products;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using lab08_SebastianGutierrez.Services.Interfaces;

namespace lab08_SebastianGutierrez.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductResponseDto>> GetProductsByPriceGreaterThanAsync(decimal price)
    {
        var products = await _productRepository.GetProductsByPriceGreaterThanAsync(price);

        return products.Select(p => new ProductResponseDto
        {
            ProductId = p.Productid,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }

    public async Task<ProductResponseDto?> GetMostExpensiveProductAsync()
    {
        var product = await _productRepository.GetMostExpensiveProductAsync();

        if (product == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            ProductId = product.Productid,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task<ProductAveragePriceDto> GetAveragePriceAsync()
    {
        var averagePrice = await _productRepository.GetAveragePriceAsync();

        return new ProductAveragePriceDto
        {
            AveragePrice = averagePrice
        };
    }

    public async Task<List<ProductResponseDto>> GetProductsWithoutDescriptionAsync()
    {
        var products = await _productRepository.GetProductsWithoutDescriptionAsync();

        return products.Select(p => new ProductResponseDto
        {
            ProductId = p.Productid,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();
    }
}