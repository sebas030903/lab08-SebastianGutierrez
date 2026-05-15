using lab08_SebastianGutierrez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab08_SebastianGutierrez.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("details-by-order/{orderId}")]
    public async Task<IActionResult> GetProductDetailsByOrderId(int orderId)
    {
        if (orderId <= 0)
        {
            return BadRequest(new
            {
                message = "El Id de la orden debe ser mayor a 0."
            });
        }

        var details = await _orderService.GetProductDetailsByOrderIdAsync(orderId);

        if (!details.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron productos para la orden indicada."
            });
        }

        return Ok(new
        {
            message = "Detalle de productos obtenido correctamente.",
            data = details
        });
    }

    [HttpGet("total-products/{orderId}")]
    public async Task<IActionResult> GetTotalProductsByOrderId(int orderId)
    {
        if (orderId <= 0)
        {
            return BadRequest(new
            {
                message = "El Id de la orden debe ser mayor a 0."
            });
        }

        var result = await _orderService.GetTotalProductsByOrderIdAsync(orderId);

        if (result.TotalProducts == 0)
        {
            return NotFound(new
            {
                message = "No se encontraron productos para la orden indicada."
            });
        }

        return Ok(new
        {
            message = "Cantidad total de productos obtenida correctamente.",
            data = result
        });
    }

    [HttpGet("after-date")]
    public async Task<IActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _orderService.GetOrdersAfterDateAsync(date);

        if (!orders.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron pedidos después de la fecha indicada."
            });
        }

        return Ok(new
        {
            message = "Pedidos obtenidos correctamente.",
            data = orders
        });
    }

    [HttpGet("all-orders-details")]
    public async Task<IActionResult> GetAllOrdersDetails()
    {
        var details = await _orderService.GetAllOrdersDetailsAsync();

        if (!details.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron detalles de pedidos registrados."
            });
        }

        return Ok(new
        {
            message = "Pedidos con sus detalles obtenidos correctamente.",
            data = details
        });
    }
    
    [HttpGet("with-details")]
    public async Task<IActionResult> GetOrdersWithDetails()
    {
        var orders = await _orderService.GetOrdersWithDetailsAsync();

        if (!orders.Any())
        {
            return NotFound(new
            {
                message = "No se encontraron pedidos con detalles."
            });
        }

        return Ok(new
        {
            message = "Pedidos con detalles obtenidos correctamente.",
            data = orders
        });
    }
}