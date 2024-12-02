using AquaProWeb.Common.Requests.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusDocumentService : ITipusDocumentService
    {
        private readonly HttpClient _httpClient;

        public TipusDocumentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusDocumentAsync(CreateTipusDocumentDTO createTipusDocumentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusDocumentEndPoints.Add, createTipusDocumentDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusDocumentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusDocumentEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusDocumentDTO>>> GetAllTipusDocumentAsync()
        {
            var response = await _httpClient.GetAsync(TipusDocumentEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusDocumentDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusDocumentDTO>> GetTipusDocumentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusDocumentEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusDocumentDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusDocumentAsync(UpdateTipusDocumentDTO updateTipusDocumentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusDocumentEndPoints.Update, updateTipusDocumentDTO);
            return await response.ToResponse<int>();
        }
    }
}
