using lab08_SebastianGutierrez.DTOs.Clients;
using lab08_SebastianGutierrez.Models;

namespace lab08_SebastianGutierrez.Repositories.Interfaces;

public interface IClientRepository
{
    Task<List<Client>> GetByNameAsync(string name);

    Task<ClientMostOrdersDto?> GetClientWithMostOrdersAsync();

    Task<List<ClientByProductDto>> GetClientsByProductIdAsync(int productId);
}