using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusViaService : ITipusViaService
    {
        private readonly HttpClient _httpClient;

        public TipusViaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusViaAsync(SaveTipusViaDTO createTipusViaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusViaEndPoints.Add, createTipusViaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusViaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusViaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusViaDTO>>> GetAllTipusViaAsync()
        {
            var response = await _httpClient.GetAsync(TipusViaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusViaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusViaDTO>> GetTipusViaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusViaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusViaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusViaAsync(SaveTipusViaDTO updateTipusViaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusViaEndPoints.Update, updateTipusViaDTO);
            return await response.ToResponse<int>();
        }
    }
}
