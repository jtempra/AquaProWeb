using AquaProWeb.Common.Requests.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusQueixaService : ITipusQueixaService
    {
        private readonly HttpClient _httpClient;

        public TipusQueixaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusQueixaAsync(SaveTipusQueixaDTO createTipusQueixaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusQueixesEndPoints.Add, createTipusQueixaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusQueixaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusQueixesEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusQueixaDTO>>> GetAllTipusQueixaAsync()
        {
            var response = await _httpClient.GetAsync(TipusQueixesEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusQueixaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusQueixaDTO>> GetTipusQueixaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusQueixesEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusQueixaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusQueixaAsync(SaveTipusQueixaDTO updateTipusQueixaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusQueixesEndPoints.Update, updateTipusQueixaDTO);
            return await response.ToResponse<int>();
        }
    }
}
