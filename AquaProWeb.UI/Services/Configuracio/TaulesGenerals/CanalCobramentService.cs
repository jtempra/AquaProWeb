using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class CanalCobramentService : ICanalCobramentService
    {
        private readonly HttpClient _httpClient;

        public CanalCobramentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddCanalCobramentAsync(SaveCanalCobramentDTO createCanalCobramentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(CanalsCobramentEndPoints.Add, createCanalCobramentDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteCanalCobramentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{CanalsCobramentEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadCanalCobramentDTO>>> GetAllCanalsCobramentAsync()
        {
            var response = await _httpClient.GetAsync(CanalsCobramentEndPoints.GetAll);
            return await response.ToResponse<List<ReadCanalCobramentDTO>>();

        }

        public async Task<ResponseWrapper<ReadCanalCobramentDTO>> GetCanalCobramentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(CanalsCobramentEndPoints.GetById(id));
            return await response.ToResponse<ReadCanalCobramentDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateCanalCobramentAsync(SaveCanalCobramentDTO updateCanalCobramentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(CanalsCobramentEndPoints.Update, updateCanalCobramentDTO);
            return await response.ToResponse<int>();
        }
    }
}
