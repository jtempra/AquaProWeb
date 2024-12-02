using AquaProWeb.Common.Requests.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusOrdreTreballService : ITipusOrdreTreballService
    {
        private readonly HttpClient _httpClient;

        public TipusOrdreTreballService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusOrdreTreballAsync(CreateTipusOrdreTreballDTO createTipusOrdreTreballDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusOrdreTreballEndPoints.Add, createTipusOrdreTreballDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusOrdreTreballAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusOrdreTreballEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>> GetAllTipusOrdreTreballAsync()
        {
            var response = await _httpClient.GetAsync(TipusOrdreTreballEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusOrdreTreballDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusOrdreTreballDTO>> GetTipusOrdreTreballByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusOrdreTreballEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusOrdreTreballDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusOrdreTreballAsync(UpdateTipusOrdreTreballDTO updateTipusOrdreTreballDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusOrdreTreballEndPoints.Update, updateTipusOrdreTreballDTO);
            return await response.ToResponse<int>();
        }
    }
}
