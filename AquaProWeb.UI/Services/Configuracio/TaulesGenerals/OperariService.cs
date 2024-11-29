using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;
using AquaProWeb.Common.Requests.TaulesGenerals.Operaris;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.UI.EndPoints.TaulesGenerals;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class OperariService 
    {
        private readonly HttpClient _httpClient;

        public OperariService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddOperariAsync(CreateOperariDTO createOperariDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(OperarisEndPoints.Add, createOperariDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteOperariAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{OperarisEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadOperariDTO>>> GetAllOperarisAsync()
        {
            var response = await _httpClient.GetAsync(OperarisEndPoints.GetAll);
            return await response.ToResponse<List<ReadOperariDTO>>();

        }

        public async Task<ResponseWrapper<ReadOperariDTO>> GetOperariByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(OperarisEndPoints.GetById(id));
            return await response.ToResponse<ReadOperariDTO>();
        }

        public async Task<ResponseWrapper<List<ReadOperariDTO>>> GetOperarisByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"OperarisEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadOperariDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateOperariAsync(UpdateOperariDTO updateOperariDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(OperarisEndPoints.Update, updateOperariDTO);
            return await response.ToResponse<int>();
        }
    }
}
