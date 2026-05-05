using lab08_SebastianGutierrez.DTOs.Products;

namespace lab08_SebastianGutierrez.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductResponseDto>> GetProductsByPriceGreaterThanAsync(decimal price);

    Task<ProductResponseDto?> GetMostExpensiveProductAsync();

    Task<ProductAveragePriceDto> GetAveragePriceAsync();

    Task<List<ProductResponseDto>> GetProductsWithoutDescriptionAsync();
}