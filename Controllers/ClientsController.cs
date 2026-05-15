using lab08_SebastianGutierrez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab08_SebastianGutierrez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("search-by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string name)
    {
     
        var clients = await _clientService.GetByNameAsync(name);

        if (!clients.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron clientes con ese nombre."
            });
        }

        return Ok(new
        {
            message = "Clientes encontrados correctamente.",
            data = clients
        });
    }

    [HttpGet("client-with-most-orders")]
    public async Task<IActionResult> GetClientWithMostOrders()
    {
        var client = await _clientService.GetClientWithMostOrdersAsync();

        if (client == null)
        {
            return NotFound(new
            {
                message = "No se encontraron pedidos registrados."
            });
        }

        return Ok(new
        {
            message = "Cliente con mayor número de pedidos obtenido correctamente.",
            data = client
        });
    }

    [HttpGet("by-product/{productId}")]
    public async Task<IActionResult> GetClientsByProductId(int productId)
    {
        if (productId <= 0)
        {
            return BadRequest(new
            {
                message = "El Id del producto debe ser mayor a 0."
            });
        }

        var clients = await _clientService.GetClientsByProductIdAsync(productId);

        if (!clients.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron clientes que hayan comprado ese producto."
            });
        }

        return Ok(new
        {
            message = "Clientes que compraron el producto obtenidos correctamente.",
            data = clients
        });
    }
    
    [HttpGet("with-orders")]
    public async Task<IActionResult> GetClientsWithOrders()
    {
        var clients = await _clientService.GetClientsWithOrdersAsync();

        if (!clients.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron clientes con pedidos."
            });
        }

        return Ok(new
        {
            message = "Clientes con sus pedidos obtenidos correctamente.",
            data = clients
        });
    }
}