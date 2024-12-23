using AquaProWeb.Common.Requests.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class PaisService : IPaisService
    {
        private readonly HttpClient _httpClient;

        public PaisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddPaisAsync(SavePaisDTO createPaisDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(PaisosEndPoints.Add, createPaisDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeletePaisAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{PaisosEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadPaisDTO>>> GetAllPaisosAsync()
        {
            var response = await _httpClient.GetAsync(PaisosEndPoints.GetAll);
            return await response.ToResponse<List<ReadPaisDTO>>();

        }

        public async Task<ResponseWrapper<ReadPaisDTO>> GetPaisByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(PaisosEndPoints.GetById(id));
            return await response.ToResponse<ReadPaisDTO>();
        }

        public async Task<ResponseWrapper<List<ReadPaisDTO>>> GetPaisosByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"PaisosEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadPaisDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdatePaisAsync(SavePaisDTO updatePaisDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(PaisosEndPoints.Update, updatePaisDTO);
            return await response.ToResponse<int>();
        }
    }
}
