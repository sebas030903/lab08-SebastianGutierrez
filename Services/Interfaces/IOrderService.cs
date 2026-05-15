using lab08_SebastianGutierrez.DTOs.Orders;

namespace lab08_SebastianGutierrez.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId);

    Task<OrderTotalProductsDto> GetTotalProductsByOrderIdAsync(int orderId);

    Task<List<OrderResponseDto>> GetOrdersAfterDateAsync(DateTime date);

    Task<List<OrderDetailResponseDto>> GetAllOrdersDetailsAsync();
    
    Task<List<OrderDetailsDto>> GetOrdersWithDetailsAsync();
}