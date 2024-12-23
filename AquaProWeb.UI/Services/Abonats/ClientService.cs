using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Abonats;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Abonats
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddClientAsync(SaveClientDTO createClientDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ClientsEndPoints.Add, createClientDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteClientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ClientsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadClientDTO>>> GetAllClientsAsync()
        {
            var response = await _httpClient.GetAsync(ClientsEndPoints.GetAll);
            return await response.ToResponse<List<ReadClientDTO>>();

        }

        public async Task<ResponseWrapper<ReadClientDTO>> GetClientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ClientsEndPoints.GetById(id));
            return await response.ToResponse<ReadClientDTO>();
        }

        public async Task<ResponseWrapper<List<ReadClientDTO>>> GetClientsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ClientsEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadClientDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateClientAsync(SaveClientDTO updateClientDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ClientsEndPoints.Update, updateClientDTO);
            return await response.ToResponse<int>();
        }
    }
}
