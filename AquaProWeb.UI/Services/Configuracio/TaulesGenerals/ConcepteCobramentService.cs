using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ConcepteCobramentService : IConcepteCobramentService
    {
        private readonly HttpClient _httpClient;

        public ConcepteCobramentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddConcepteCobramentAsync(SaveConcepteCobramentDTO createConcepteCobramentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ConceptesCobramentEndPoints.Add, createConcepteCobramentDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteConcepteCobramentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ConceptesCobramentEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> GetAllConceptesCobramentAsync()
        {
            var response = await _httpClient.GetAsync(ConceptesCobramentEndPoints.GetAll);
            return await response.ToResponse<List<ReadConcepteCobramentDTO>>();

        }

        public async Task<ResponseWrapper<ReadConcepteCobramentDTO>> GetConcepteCobramentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ConceptesCobramentEndPoints.GetById(id));
            return await response.ToResponse<ReadConcepteCobramentDTO>();
        }

        public async Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> GetConceptesCobramentByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ConceptesCobramentEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadConcepteCobramentDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateConcepteCobramentAsync(SaveConcepteCobramentDTO updateConcepteCobramentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ConceptesCobramentEndPoints.Update, updateConcepteCobramentDTO);
            return await response.ToResponse<int>();
        }
    }
}
