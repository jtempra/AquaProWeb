using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class CompteTransferenciaClientService : ICompteTransferenciaClientService
    {
        private readonly HttpClient _httpClient;

        public CompteTransferenciaClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddCompteTransferenciaClientAsync(SaveCompteTransferenciaClientDTO createCompteTransferenciaClientDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ComptesTransferenciaClientEndPoints.Add, createCompteTransferenciaClientDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteCompteTransferenciaClientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ComptesTransferenciaClientEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetAllComptesTransferenciaClientAsync()
        {
            var response = await _httpClient.GetAsync(ComptesTransferenciaClientEndPoints.GetAll);
            return await response.ToResponse<List<ReadCompteTransferenciaClientDTO>>();

        }

        public async Task<ResponseWrapper<ReadCompteTransferenciaClientDTO>> GetCompteTransferenciaClientByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ComptesTransferenciaClientEndPoints.GetById(id));
            return await response.ToResponse<ReadCompteTransferenciaClientDTO>();
        }

        public async Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetComptesTransferenciaClientByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ComptesTransferenciaClientEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadCompteTransferenciaClientDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateCompteTransferenciaClientAsync(SaveCompteTransferenciaClientDTO updateCompteTransferenciaClientDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ComptesTransferenciaClientEndPoints.Update, updateCompteTransferenciaClientDTO);
            return await response.ToResponse<int>();
        }
    }
}
