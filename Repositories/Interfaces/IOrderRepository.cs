using lab08_SebastianGutierrez.DTOs.Orders;
using lab08_SebastianGutierrez.Models;

namespace lab08_SebastianGutierrez.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<List<OrderProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId);

    Task<int> GetTotalProductsByOrderIdAsync(int orderId);

    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);

    Task<List<OrderDetailResponseDto>> GetAllOrdersDetailsAsync();
}