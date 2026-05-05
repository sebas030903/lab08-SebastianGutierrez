namespace lab08_SebastianGutierrez.DTOs.Clients;

public class ClientMostOrdersDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public int TotalOrders { get; set; }
}