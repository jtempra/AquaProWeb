using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Explotacions;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.Explotacion
{
    public class ExplotacioService : IExplotacioService
    {
        private readonly HttpClient _httpClient;

        public ExplotacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddExplotacioAsync(SaveExplotacioDTO createExplotacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ExplotacionsEndPoints.Add, createExplotacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteExplotacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ExplotacionsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadExplotacioDTO>>> GetAllExplotacionsAsync()
        {
            var response = await _httpClient.GetAsync(ExplotacionsEndPoints.GetAll);
            return await response.ToResponse<List<ReadExplotacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadExplotacioDTO>> GetExplotacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ExplotacionsEndPoints.GetById(id));
            return await response.ToResponse<ReadExplotacioDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateExplotacioAsync(SaveExplotacioDTO updateExplotacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ExplotacionsEndPoints.Update, updateExplotacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
