using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class PoblacioService : IPoblacioService
    {
        private readonly HttpClient _httpClient;

        public PoblacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddPoblacioAsync(SavePoblacioDTO createPoblacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(PoblacionsEndPoints.Add, createPoblacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeletePoblacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{PoblacionsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadPoblacioDTO>>> GetAllPoblacionsAsync()
        {
            var response = await _httpClient.GetAsync(PoblacionsEndPoints.GetAll);
            return await response.ToResponse<List<ReadPoblacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadPoblacioDTO>> GetPoblacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(PoblacionsEndPoints.GetById(id));
            return await response.ToResponse<ReadPoblacioDTO>();
        }

        public async Task<ResponseWrapper<List<ReadPoblacioDTO>>> GetPoblacionsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"{PoblacionsEndPoints.GetByText}/{text}");
            return await response.ToResponse<List<ReadPoblacioDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdatePoblacioAsync(SavePoblacioDTO updatePoblacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(PoblacionsEndPoints.Update, updatePoblacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
