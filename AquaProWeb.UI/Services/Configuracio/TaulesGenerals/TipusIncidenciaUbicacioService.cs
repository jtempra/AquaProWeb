using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusIncidenciaUbicacioService : ITipusIncidenciaUbicacioService
    {
        private readonly HttpClient _httpClient;

        public TipusIncidenciaUbicacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusIncidenciaUbicacioAsync(CreateTipusIncidenciaUbicacioDTO createTipusIncidenciaUbicacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusIncidenciaUbicacionsEndPoints.Add, createTipusIncidenciaUbicacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusIncidenciaUbicacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusIncidenciaUbicacionsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>> GetAllTipusIncidenciaUbicacioAsync()
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaUbicacionsEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusIncidenciaUbicacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>> GetTipusIncidenciaUbicacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaUbicacionsEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusIncidenciaUbicacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusIncidenciaUbicacioAsync(UpdateTipusIncidenciaUbicacioDTO updateTipusIncidenciaUbicacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusIncidenciaUbicacionsEndPoints.Update, updateTipusIncidenciaUbicacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
