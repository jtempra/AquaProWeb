using AquaProWeb.Common.Requests.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ZonaUbicacioService : IZonaUbicacioService
    {
        private readonly HttpClient _httpClient;

        public ZonaUbicacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddZonaUbicacioAsync(CreateZonaUbicacioDTO createZonaUbicacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ZonesCarrerEndPoints.Add, createZonaUbicacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteZonaUbicacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ZonesCarrerEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadZonaUbicacioDTO>>> GetAllZonesCarrerAsync()
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetAll);
            return await response.ToResponse<List<ReadZonaUbicacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadZonaUbicacioDTO>> GetZonaUbicacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetById(id));
            return await response.ToResponse<ReadZonaUbicacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateZonaUbicacioAsync(UpdateZonaUbicacioDTO updateZonaUbicacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ZonesCarrerEndPoints.Update, updateZonaUbicacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
