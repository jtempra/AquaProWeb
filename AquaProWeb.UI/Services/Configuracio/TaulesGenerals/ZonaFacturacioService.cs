using AquaProWeb.Common.Requests.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ZonaFacturacioService : IZonaFacturacioService
    {
        private readonly HttpClient _httpClient;

        public ZonaFacturacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddZonaFacturacioAsync(CreateZonaFacturacioDTO createZonaFacturacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ZonesCarrerEndPoints.Add, createZonaFacturacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteZonaFacturacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ZonesCarrerEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadZonaFacturacioDTO>>> GetAllZonesCarrerAsync()
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetAll);
            return await response.ToResponse<List<ReadZonaFacturacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadZonaFacturacioDTO>> GetZonaFacturacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetById(id));
            return await response.ToResponse<ReadZonaFacturacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateZonaFacturacioAsync(UpdateZonaFacturacioDTO updateZonaFacturacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ZonesCarrerEndPoints.Update, updateZonaFacturacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
