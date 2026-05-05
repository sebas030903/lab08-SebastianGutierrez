using lab08_SebastianGutierrez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab08_SebastianGutierrez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("price-greater-than")]
    public async Task<IActionResult> GetProductsByPriceGreaterThan([FromQuery] decimal price)
    {
        if (price < 0)
        {
            return BadRequest(new
            {
                message = "El precio no puede ser negativo."
            });
        }

        var products = await _productService.GetProductsByPriceGreaterThanAsync(price);

        if (!products.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron productos con precio mayor al valor indicado."
            });
        }

        return Ok(new
        {
            message = "Productos encontrados correctamente.",
            data = products
        });
    }

    [HttpGet("most-expensive")]
    public async Task<IActionResult> GetMostExpensiveProduct()
    {
        var product = await _productService.GetMostExpensiveProductAsync();

        if (product == null)
        {
            return NotFound(new
            {
                message = "No se encontraron productos registrados."
            });
        }

        return Ok(new
        {
            message = "Producto más caro obtenido correctamente.",
            data = product
        });
    }

    [HttpGet("average-price")]
    public async Task<IActionResult> GetAveragePrice()
    {
        var result = await _productService.GetAveragePriceAsync();

        return Ok(new
        {
            message = "Precio promedio obtenido correctamente.",
            data = result
        });
    }

    [HttpGet("without-description")]
    public async Task<IActionResult> GetProductsWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();

        if (!products.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron productos sin descripción."
            });
        }

        return Ok(new
        {
            message = "Productos sin descripción obtenidos correctamente.",
            data = products
        });
    }
}