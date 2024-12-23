
using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusConcepteFacturaService : ITipusConcepteFacturaService
    {
        private readonly HttpClient _httpClient;

        public TipusConcepteFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusConcepteFacturaAsync(SaveTipusConcepteFacturaDTO createTipusConcepteFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusConcepteFacturaEndPoints.Add, createTipusConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusConcepteFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusConcepteFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>> GetAllTipusConcepteFacturaAsync()
        {
            var response = await _httpClient.GetAsync(TipusConcepteFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusConcepteFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusConcepteFacturaDTO>> GetTipusConcepteFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusConcepteFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusConcepteFacturaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusConcepteFacturaAsync(SaveTipusConcepteFacturaDTO updateTipusConcepteFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusConcepteFacturaEndPoints.Update, updateTipusConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
