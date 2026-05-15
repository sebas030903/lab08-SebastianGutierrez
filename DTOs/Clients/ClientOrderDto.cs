using lab08_SebastianGutierrez.DTOs.Orders;

namespace lab08_SebastianGutierrez.DTOs.Clients;

public class ClientOrderDto
{
    public string ClientName { get; set; } = null!;
    public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
}