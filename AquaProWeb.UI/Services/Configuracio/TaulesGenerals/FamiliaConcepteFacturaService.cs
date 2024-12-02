using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class FamiliaConcepteFacturaService : IFamiliaConcepteFacturaService
    {
        private readonly HttpClient _httpClient;

        public FamiliaConcepteFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddFamiliaConcepteFacturaAsync(CreateFamiliaConcepteFacturaDTO createFamiliaConcepteFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(FamiliesConcepteFacturaEndPoints.Add, createFamiliaConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteFamiliaConcepteFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{FamiliesConcepteFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> GetAllFamiliesConcepteFacturaAsync()
        {
            var response = await _httpClient.GetAsync(FamiliesConcepteFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadFamiliaConcepteFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadFamiliaConcepteFacturaDTO>> GetFamiliaConcepteFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(FamiliesConcepteFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadFamiliaConcepteFacturaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> GetFamiliesConcepteFacturaByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"FamiliesConcepteFacturaEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadFamiliaConcepteFacturaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateFamiliaConcepteFacturaAsync(UpdateFamiliaConcepteFacturaDTO updateFamiliaConcepteFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(ConceptesFacturaEndPoints.Update, updateFamiliaConcepteFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
