using AquaProWeb.Common.Requests.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusReclamacioService 
    {
        private readonly HttpClient _httpClient;

        public TipusReclamacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusReclamacioAsync(CreateTipusReclamacioDTO createTipusReclamacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusReclamacionsEndPoints.Add, createTipusReclamacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusReclamacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusReclamacionsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusReclamacioDTO>>> GetAllTipusReclamacioAsync()
        {
            var response = await _httpClient.GetAsync(TipusReclamacionsEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusReclamacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusReclamacioDTO>> GetTipusReclamacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusReclamacionsEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusReclamacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusReclamacioAsync(UpdateTipusReclamacioDTO updateTipusReclamacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusReclamacionsEndPoints.Update, updateTipusReclamacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
