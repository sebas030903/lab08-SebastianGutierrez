using lab08_SebastianGutierrez.DTOs.Products;

namespace lab08_SebastianGutierrez.DTOs.Orders;

public class OrderDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
}