using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusIncidenciaTecnicaService : ITipusIncidenciaTecnicaService
    {
        private readonly HttpClient _httpClient;

        public TipusIncidenciaTecnicaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusIncidenciaTecnicaAsync(SaveTipusIncidenciaTecnicaDTO createTipusIncidenciaTecnicaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusIncidenciaTecnicaEndPoints.Add, createTipusIncidenciaTecnicaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusIncidenciaTecnicaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusIncidenciaTecnicaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>> GetAllTipusIncidenciaTecnicaAsync()
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaTecnicaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusIncidenciaTecnicaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>> GetTipusIncidenciaTecnicaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaTecnicaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusIncidenciaTecnicaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusIncidenciaTecnicaAsync(SaveTipusIncidenciaTecnicaDTO updateTipusIncidenciaTecnicaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusIncidenciaTecnicaEndPoints.Update, updateTipusIncidenciaTecnicaDTO);
            return await response.ToResponse<int>();
        }
    }
}
