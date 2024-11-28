using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class ConcepteFacturaService : IConcepteFacturaService
    {
        private readonly HttpClient _httpClient;

        public ConcepteFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddConcepteFacturaAsync(CreateConcepteFacturaDTO createConcepteFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(ConceptesFacturaEndPoints.Add, createConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteConcepteFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{ConceptesFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> GetAllConceptesFacturaAsync()
        {
            var response = await _httpClient.GetAsync(ConceptesFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadConcepteFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadConcepteFacturaDTO>> GetConcepteFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(ConceptesFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadConcepteFacturaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> GetConceptesFacturaByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"ConceptesFacturaEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadConcepteFacturaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateConcepteFacturaAsync(UpdateConcepteFacturaDTO updateConcepteFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ConceptesFacturaEndPoints.Update, updateConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
