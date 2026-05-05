using lab08_SebastianGutierrez.DTOs.Clients;
using lab08_SebastianGutierrez.Repositories.Interfaces;
using lab08_SebastianGutierrez.Services.Interfaces;

namespace lab08_SebastianGutierrez.Services.Implementations;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientResponseDto>> GetByNameAsync(string name)
    {
        var clients = await _clientRepository.GetByNameAsync(name);

        return clients.Select(c => new ClientResponseDto
        {
            ClientId = c.Clientid,
            Name = c.Name,
            Email = c.Email
        }).ToList();
    }

    public async Task<ClientMostOrdersDto?> GetClientWithMostOrdersAsync()
    {
        return await _clientRepository.GetClientWithMostOrdersAsync();
    }

    public async Task<List<ClientByProductDto>> GetClientsByProductIdAsync(int productId)
    {
        return await _clientRepository.GetClientsByProductIdAsync(productId);
    }
}