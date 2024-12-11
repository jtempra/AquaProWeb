using AquaProWeb.Common.Requests.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusUbicacioService : ITipusUbicacioService
    {
        private readonly HttpClient _httpClient;

        public TipusUbicacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusUbicacioAsync(CreateTipusUbicacioDTO createTipusUbicacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusUbicacioEndPoints.Add, createTipusUbicacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusUbicacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusUbicacioEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusUbicacioDTO>>> GetAllTipusUbicacioAsync()
        {
            var response = await _httpClient.GetAsync(TipusUbicacioEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusUbicacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusUbicacioDTO>> GetTipusUbicacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusUbicacioEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusUbicacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusUbicacioAsync(UpdateTipusUbicacioDTO updateTipusUbicacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusUbicacioEndPoints.Update, updateTipusUbicacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
