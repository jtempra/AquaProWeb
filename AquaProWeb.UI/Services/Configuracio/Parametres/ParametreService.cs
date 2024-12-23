using AquaProWeb.Common.Requests.Parametres;
using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Parametres;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{

    public class ParametreService : IParametreService
    {
        private readonly HttpClient _httpClient;

        public ParametreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddParametreAsync(SaveParametreDTO createParametreDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ParametresEndPoints.Add, createParametreDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteParametreAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ParametresEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadParametreDTO>>> GetAllParametresAsync()
        {
            var response = await _httpClient.GetAsync(ParametresEndPoints.GetAll);
            return await response.ToResponse<List<ReadParametreDTO>>();

        }

        public async Task<ResponseWrapper<ReadParametreDTO>> GetParametreByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ParametresEndPoints.GetById(id));
            return await response.ToResponse<ReadParametreDTO>();
        }

        public async Task<ResponseWrapper<List<ReadParametreDTO>>> GetParametresByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ParametresEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadParametreDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateParametreAsync(SaveParametreDTO updateParametreDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ParametresEndPoints.Update, updateParametreDTO);
            return await response.ToResponse<int>();
        }
    }

}
