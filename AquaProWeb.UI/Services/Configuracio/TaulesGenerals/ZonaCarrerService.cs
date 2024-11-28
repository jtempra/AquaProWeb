using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ZonaCarrerService : IZonaCarrerService
    {
        private readonly HttpClient _httpClient;

        public ZonaCarrerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddZonaCarrerAsync(CreateZonaCarrerDTO createZonaCarrerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ZonesCarrerEndPoints.Add, createZonaCarrerDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteZonaCarrerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ZonesCarrerEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadZonaCarrerDTO>>> GetAllZonesCarrerAsync()
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetAll);
            return await response.ToResponse<List<ReadZonaCarrerDTO>>();

        }

        public async Task<ResponseWrapper<ReadZonaCarrerDTO>> GetZonaCarrerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetById(id));
            return await response.ToResponse<ReadZonaCarrerDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateZonaCarrerAsync(UpdateZonaCarrerDTO updateZonaCarrerDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ZonesCarrerEndPoints.Update, updateZonaCarrerDTO);
            return await response.ToResponse<int>();
        }
    }
}
