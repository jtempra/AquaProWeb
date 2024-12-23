using AquaProWeb.Common.Requests.TaulesGenerals.SituacioFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class SituacioFacturaService : ISituacioFacturaService
    {
        private readonly HttpClient _httpClient;

        public SituacioFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddSituacioFacturaAsync(SaveSituacioFacturaDTO createSituacioFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(SituacionsFacturaEndPoints.Add, createSituacioFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteSituacioFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{SituacionsFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> GetAllSituacionsFacturasAsync()
        {
            var response = await _httpClient.GetAsync(SituacionsFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadSituacioFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadSituacioFacturaDTO>> GetSituacioFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(SituacionsFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadSituacioFacturaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> GetSituacionsFacturasByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"SituacionsFacturaEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadSituacioFacturaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateSituacioFacturaAsync(SaveSituacioFacturaDTO updateSituacioFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(SituacionsFacturaEndPoints.Update, updateSituacioFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
