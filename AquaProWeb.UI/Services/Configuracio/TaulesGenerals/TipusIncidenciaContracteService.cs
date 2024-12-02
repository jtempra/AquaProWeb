using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusIncidenciaContracteService : ITipusIncidenciaContracteService
    {
        private readonly HttpClient _httpClient;

        public TipusIncidenciaContracteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusIncidenciaContracteAsync(CreateTipusIncidenciaContracteDTO createTipusIncidenciaContracteDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusIncidenciaContracteEndPoints.Add, createTipusIncidenciaContracteDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusIncidenciaContracteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusIncidenciaContracteEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>> GetAllTipusIncidenciaContracteAsync()
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaContracteEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusIncidenciaContracteDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusIncidenciaContracteDTO>> GetTipusIncidenciaContracteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaContracteEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusIncidenciaContracteDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusIncidenciaContracteAsync(UpdateTipusIncidenciaContracteDTO updateTipusIncidenciaContracteDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusIncidenciaContracteEndPoints.Update, updateTipusIncidenciaContracteDTO);
            return await response.ToResponse<int>();
        }
    }
}
