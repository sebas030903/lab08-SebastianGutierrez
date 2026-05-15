using lab08_SebastianGutierrez.Data;
using lab08_SebastianGutierrez.DTOs.Clients;
using lab08_SebastianGutierrez.Models;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using lab08_SebastianGutierrez.DTOs.Orders;

namespace lab08_SebastianGutierrez.Repositories.Implementations;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.ToLower().StartsWith(name.ToLower()))
            .ToListAsync();
    }

    public async Task<ClientMostOrdersDto?> GetClientWithMostOrdersAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => new ClientMostOrdersDto
            {
                ClientId = g.Key,
                ClientName = _context.Clients
                    .Where(c => c.Clientid == g.Key)
                    .Select(c => c.Name)
                    .FirstOrDefault()!,
                TotalOrders = g.Count()
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<ClientByProductDto>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.Productid == productId)
            .Select(od => new ClientByProductDto
            {
                ClientId = od.Order.Client.Clientid,
                ClientName = od.Order.Client.Name,
                Email = od.Order.Client.Email,
                ProductId = od.Product.Productid,
                ProductName = od.Product.Name
            })
            .ToListAsync();
    }
    public async Task<List<ClientOrderDto>> GetClientsWithOrdersAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(client => new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = client.Orders
                    .Select(order => new OrderDto
                    {
                        OrderId = order.Orderid,
                        OrderDate = order.Orderdate
                    }).ToList()
            })
            .ToListAsync();
    }
    
    public async Task<List<ClientProductCountDto>> GetClientsWithProductCountAsync()
    {
        return await _context.Clients
            .AsNoTracking()
            .Select(client => new ClientProductCountDto
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .Sum(order => order.Orderdetails
                        .Sum(detail => detail.Quantity))
            })
            .ToListAsync();
    }
}