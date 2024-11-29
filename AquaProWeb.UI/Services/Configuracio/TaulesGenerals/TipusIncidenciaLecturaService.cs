using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusIncidenciaLecturaService 
    {
        private readonly HttpClient _httpClient;

        public TipusIncidenciaLecturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusIncidenciaLecturaAsync(CreateTipusIncidenciaLecturaDTO createTipusIncidenciaLecturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusIncidenciaLecturaEndPoints.Add, createTipusIncidenciaLecturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusIncidenciaLecturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusIncidenciaLecturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>> GetAllTipusIncidenciaLecturaAsync()
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaLecturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusIncidenciaLecturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusIncidenciaLecturaDTO>> GetTipusIncidenciaLecturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusIncidenciaLecturaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusIncidenciaLecturaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusIncidenciaLecturaAsync(UpdateTipusIncidenciaLecturaDTO updateTipusIncidenciaLecturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusIncidenciaLecturaEndPoints.Update, updateTipusIncidenciaLecturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
