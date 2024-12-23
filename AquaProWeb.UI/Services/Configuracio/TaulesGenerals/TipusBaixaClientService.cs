using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusBaixaClientService : ITipusBaixaClientService
    {
        private readonly HttpClient _httpClient;

        public TipusBaixaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusBaixaClientAsync(SaveTipusBaixaClientDTO createTipusBaixaClientDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusBaixaClientEndPoints.Add, createTipusBaixaClientDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusBaixaClientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusBaixaClientEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusBaixaClientDTO>>> GetAllTipusBaixaClientAsync()
        {
            var response = await _httpClient.GetAsync(TipusBaixaClientEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusBaixaClientDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusBaixaClientDTO>> GetTipusBaixaClientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusBaixaClientEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusBaixaClientDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusBaixaClientAsync(SaveTipusBaixaClientDTO updateTipusBaixaClientDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusBaixaClientEndPoints.Update, updateTipusBaixaClientDTO);
            return await response.ToResponse<int>();
        }
    }
}
