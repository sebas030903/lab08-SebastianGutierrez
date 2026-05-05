namespace lab08_SebastianGutierrez.DTOs.Orders;

public class OrderProductDetailDto
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}