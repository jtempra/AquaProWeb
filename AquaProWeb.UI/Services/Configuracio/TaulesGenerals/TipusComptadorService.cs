using AquaProWeb.Common.Requests.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusComptadorService 
    {
        private readonly HttpClient _httpClient;

        public TipusComptadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusComptadorAsync(CreateTipusComptadorDTO createTipusComptadorDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusComptadorEndPoints.Add, createTipusComptadorDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusComptadorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusComptadorEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusComptadorDTO>>> GetAllTipusComptadorAsync()
        {
            var response = await _httpClient.GetAsync(TipusComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusComptadorDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusComptadorDTO>> GetTipusComptadorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusComptadorDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusComptadorAsync(UpdateTipusComptadorDTO updateTipusComptadorDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusComptadorEndPoints.Update, updateTipusComptadorDTO);
            return await response.ToResponse<int>();
        }
    }
}
