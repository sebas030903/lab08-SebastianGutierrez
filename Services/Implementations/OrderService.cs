using lab08_SebastianGutierrez.DTOs.Orders;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using lab08_SebastianGutierrez.Services.Interfaces;

namespace lab08_SebastianGutierrez.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId)
    {
        return await _orderRepository.GetProductDetailsByOrderIdAsync(orderId);
    }

    public async Task<OrderTotalProductsDto> GetTotalProductsByOrderIdAsync(int orderId)
    {
        var totalProducts = await _orderRepository.GetTotalProductsByOrderIdAsync(orderId);

        return new OrderTotalProductsDto
        {
            OrderId = orderId,
            TotalProducts = totalProducts
        };
    }

    public async Task<List<OrderResponseDto>> GetOrdersAfterDateAsync(DateTime date)
    {
        var orders = await _orderRepository.GetOrdersAfterDateAsync(date);

        return orders.Select(o => new OrderResponseDto
        {
            OrderId = o.Orderid,
            ClientId = o.Clientid,
            ClientName = o.Client.Name,
            OrderDate = o.Orderdate
        }).ToList();
    }

    public async Task<List<OrderDetailResponseDto>> GetAllOrdersDetailsAsync()
    {
        return await _orderRepository.GetAllOrdersDetailsAsync();
    }
    
    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsAsync()
    {
        return await _orderRepository.GetOrdersWithDetailsAsync();
    }
}