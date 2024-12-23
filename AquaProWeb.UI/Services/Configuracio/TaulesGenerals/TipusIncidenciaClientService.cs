using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusIncidenciaClientService : ITipusIncidenciaClientService
    {
        private readonly HttpClient _httpClient;

        public TipusIncidenciaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusIncidenciaClientAsync(SaveTipusIncidenciaClientDTO createTipusIncidenciaClientDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusIncidenciaClientEndPoints.Add, createTipusIncidenciaClientDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusIncidenciaClientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusIncidenciaClientEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>> GetAllTipusIncidenciaClientAsync()
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaClientEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusIncidenciaClientDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusIncidenciaClientDTO>> GetTipusIncidenciaClientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaClientEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusIncidenciaClientDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusIncidenciaClientAsync(SaveTipusIncidenciaClientDTO updateTipusIncidenciaClientDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusIncidenciaClientEndPoints.Update, updateTipusIncidenciaClientDTO);
            return await response.ToResponse<int>();
        }
    }
}
