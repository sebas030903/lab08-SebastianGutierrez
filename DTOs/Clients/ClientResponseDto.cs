namespace lab08_SebastianGutierrez.DTOs.Clients;

public class ClientResponseDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}