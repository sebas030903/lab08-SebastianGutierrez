namespace lab08_SebastianGutierrez.DTOs.Orders;

public class OrderDetailResponseDto
{
    public int OrderId { get; set; }
    public int OrderDetailId { get; set; }
    public string ClientName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}