namespace lab08_SebastianGutierrez.DTOs.Products;

public class ProductResponseDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}