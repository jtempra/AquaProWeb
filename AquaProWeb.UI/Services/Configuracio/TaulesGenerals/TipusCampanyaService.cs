using AquaProWeb.Common.Requests.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusCampanyaService : ITipusCampanyaService
    {
        private readonly HttpClient _httpClient;

        public TipusCampanyaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusCampanyaAsync(CreateTipusCampanyaDTO createTipusCampanyaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusCampanyaEndPoints.Add, createTipusCampanyaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusCampanyaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusCampanyaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusCampanyaDTO>>> GetAllTipusCampanyaAsync()
        {
            var response = await _httpClient.GetAsync(TipusCampanyaEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusCampanyaDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusCampanyaDTO>> GetTipusCampanyaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusCampanyaEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusCampanyaDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusCampanyaAsync(UpdateTipusCampanyaDTO updateTipusCampanyaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusCampanyaEndPoints.Update, updateTipusCampanyaDTO);
            return await response.ToResponse<int>();
        }
    }
}
