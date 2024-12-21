using AquaProWeb.Common.Requests.Abonats.Escomeses;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Abonats;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Abonats
{
    public class EscomesaService : IEscomesaService
    {
        private readonly HttpClient _httpClient;

        public EscomesaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddEscomesaAsync(CreateEscomesaDTO createEscomesaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(EscomesesEndPoints.Add, createEscomesaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteEscomesaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{EscomesesEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadEscomesaDTO>>> GetAllEscomesesAsync()
        {
            var response = await _httpClient.GetAsync(EscomesesEndPoints.GetAll);
            return await response.ToResponse<List<ReadEscomesaDTO>>();

        }

        public async Task<ResponseWrapper<ReadEscomesaDTO>> GetEscomesaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(EscomesesEndPoints.GetById(id));
            return await response.ToResponse<ReadEscomesaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadEscomesaDTO>>> GetEscomesesByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"EscomesesEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadEscomesaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateEscomesaAsync(UpdateEscomesaDTO updateEscomesaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(EscomesesEndPoints.Update, updateEscomesaDTO);
            return await response.ToResponse<int>();
        }
    }
}
