namespace lab08_SebastianGutierrez.DTOs.Clients;

public class ClientByProductDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
}