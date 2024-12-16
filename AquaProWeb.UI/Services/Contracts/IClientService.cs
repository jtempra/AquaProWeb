using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IClientService
{
    Task<ResponseWrapper<int>> AddClientAsync(CreateClientDTO createClientDTO);
    Task<ResponseWrapper<int>> DeleteClientAsync(int id);
    Task<ResponseWrapper<List<ReadClientDTO>>> GetAllClientsAsync();
    Task<ResponseWrapper<ReadClientDTO>> GetClientByIdAsync(int id);
    Task<ResponseWrapper<List<ReadClientDTO>>> GetClientsByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateClientAsync(UpdateClientDTO updateClientDTO);
}