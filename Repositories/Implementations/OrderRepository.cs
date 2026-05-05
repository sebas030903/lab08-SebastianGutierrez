using lab08_SebastianGutierrez.Data;
using lab08_SebastianGutierrez.DTOs.Orders;
using lab08_SebastianGutierrez.Models;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lab08_SebastianGutierrez.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderProductDetailDto>> GetProductDetailsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => new OrderProductDetailDto
            {
                OrderId = od.Orderid,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }

    public async Task<int> GetTotalProductsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }

    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Where(o => o.Orderdate > date)
            .ToListAsync();
    }

    public async Task<List<OrderDetailResponseDto>> GetAllOrdersDetailsAsync()
    {
        return await _context.Orderdetails
            .Where(od => od.Orderdetailid > 0)
            .Select(od => new OrderDetailResponseDto
            {
                OrderId = od.Orderid,
                OrderDetailId = od.Orderdetailid,
                ClientName = od.Order.Client.Name,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
}