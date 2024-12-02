using AquaProWeb.Common.Requests.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ZonaOrdreTreballService : IZonaOrdreTreballService
    {
        private readonly HttpClient _httpClient;

        public ZonaOrdreTreballService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddZonaOrdreTreballAsync(CreateZonaOrdreTreballDTO createZonaOrdreTreballDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ZonesCarrerEndPoints.Add, createZonaOrdreTreballDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteZonaOrdreTreballAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ZonesCarrerEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>> GetAllZonesCarrerAsync()
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetAll);
            return await response.ToResponse<List<ReadZonaOrdreTreballDTO>>();

        }

        public async Task<ResponseWrapper<ReadZonaOrdreTreballDTO>> GetZonaOrdreTreballByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ZonesCarrerEndPoints.GetById(id));
            return await response.ToResponse<ReadZonaOrdreTreballDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateZonaOrdreTreballAsync(UpdateZonaOrdreTreballDTO updateZonaOrdreTreballDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ZonesCarrerEndPoints.Update, updateZonaOrdreTreballDTO);
            return await response.ToResponse<int>();
        }
    }
}
