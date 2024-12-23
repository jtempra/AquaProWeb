using AquaProWeb.Common.Requests.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusClientService : ITipusClientService
    {
        private readonly HttpClient _httpClient;

        public TipusClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusClientAsync(SaveTipusClientDTO createTipusClientDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusClientEndPoints.Add, createTipusClientDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusClientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusClientEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusClientDTO>>> GetAllTipusClientsAsync()
        {
            var response = await _httpClient.GetAsync(TipusClientEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusClientDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusClientDTO>> GetTipusClientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusClientEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusClientDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusClientAsync(SaveTipusClientDTO updateTipusClientDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusClientEndPoints.Update, updateTipusClientDTO);
            return await response.ToResponse<int>();
        }
    }
}
