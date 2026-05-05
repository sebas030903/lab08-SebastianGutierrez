using lab08_SebastianGutierrez.DTOs.Clients;

namespace lab08_SebastianGutierrez.Services.Interfaces;

public interface IClientService
{
    Task<List<ClientResponseDto>> GetByNameAsync(string name);

    Task<ClientMostOrdersDto?> GetClientWithMostOrdersAsync();

    Task<List<ClientByProductDto>> GetClientsByProductIdAsync(int productId);
}