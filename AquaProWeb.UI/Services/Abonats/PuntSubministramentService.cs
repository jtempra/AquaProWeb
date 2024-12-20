using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Abonats;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Abonats
{
    public class PuntSubministramentService : IPuntSubministramentService
    {
        private readonly HttpClient _httpClient;

        public PuntSubministramentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddPuntSubministramentAsync(CreatePuntSubministramentDTO createPuntSubministramentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(PuntsSubministramentEndPoints.Add, createPuntSubministramentDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeletePuntSubministramentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{PuntsSubministramentEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadPuntSubministramentDTO>>> GetAllPuntsSubministramentAsync()
        {
            var response = await _httpClient.GetAsync(PuntsSubministramentEndPoints.GetAll);
            return await response.ToResponse<List<ReadPuntSubministramentDTO>>();

        }

        public async Task<ResponseWrapper<ReadPuntSubministramentDTO>> GetPuntSubministramentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(PuntsSubministramentEndPoints.GetById(id));
            return await response.ToResponse<ReadPuntSubministramentDTO>();
        }

        public async Task<ResponseWrapper<List<ReadPuntSubministramentDTO>>> GetPuntsSubministramentByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"PuntsSubministramentEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadPuntSubministramentDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdatePuntSubministramentAsync(UpdatePuntSubministramentDTO updatePuntSubministramentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(PuntsSubministramentEndPoints.Update, updatePuntSubministramentDTO);
            return await response.ToResponse<int>();
        }
    }
}
