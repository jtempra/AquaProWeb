
using AquaProWeb.Common.Requests.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusFacturaService 
    {
        private readonly HttpClient _httpClient;

        public TipusFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusFacturaAsync(CreateTipusFacturaDTO createTipusFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusFacturaEndPoints.Add, createTipusFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusFacturaDTO>>> GetAllTipusFacturaAsync()
        {
            var response = await _httpClient.GetAsync(TipusFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusFacturaDTO>> GetTipusFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusFacturaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusFacturaAsync(UpdateTipusFacturaDTO updateTipusFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusFacturaEndPoints.Update, updateTipusFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
