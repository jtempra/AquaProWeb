using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class CompteRemesaBancService
    {
        private readonly HttpClient _httpClient;

        public CompteRemesaBancService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddCompteRemesaBancAsync(CreateCompteRemesaBancDTO createCompteRemesaBancDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ComptesRemesaBancEndPoints.Add, createCompteRemesaBancDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteCompteRemesaBancAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ComptesRemesaBancEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> GetAllComptesRemesaBancAsync()
        {
            var response = await _httpClient.GetAsync(ComptesRemesaBancEndPoints.GetAll);
            return await response.ToResponse<List<ReadCompteRemesaBancDTO>>();

        }

        public async Task<ResponseWrapper<ReadCompteRemesaBancDTO>> GetCompteRemesaBancByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ComptesRemesaBancEndPoints.GetById(id));
            return await response.ToResponse<ReadCompteRemesaBancDTO>();
        }

        public async Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> GetComptesRemesaBancByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ComptesRemesaBancEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadCompteRemesaBancDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateCompteRemesaBancAsync(UpdateCarrerDTO updateCompteRemesaBancDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ComptesRemesaBancEndPoints.Update, updateCompteRemesaBancDTO);
            return await response.ToResponse<int>();
        }
    }
}
