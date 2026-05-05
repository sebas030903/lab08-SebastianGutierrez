namespace lab08_SebastianGutierrez.DTOs.Orders;

public class OrderResponseDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
}