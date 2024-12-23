using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class FamiliaContracteService : IFamiliaContracteService
    {
        private readonly HttpClient _httpClient;

        public FamiliaContracteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddFamiliaContracteAsync(SaveFamiliaContracteDTO createFamiliaContracteDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(FamiliesContracteEndPoints.Add, createFamiliaContracteDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteFamiliaContracteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{FamiliesContracteEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> GetAllFamiliesContracteAsync()
        {
            var response = await _httpClient.GetAsync(FamiliesContracteEndPoints.GetAll);
            return await response.ToResponse<List<ReadFamiliaContracteDTO>>();

        }

        public async Task<ResponseWrapper<ReadFamiliaContracteDTO>> GetFamiliaContracteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(FamiliesContracteEndPoints.GetById(id));
            return await response.ToResponse<ReadFamiliaContracteDTO>();
        }

        public async Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> GetFamiliesContracteByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"FamiliesContracteEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadFamiliaContracteDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateFamiliaContracteAsync(SaveFamiliaContracteDTO updateFamiliaContracteDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(FamiliesContracteEndPoints.Update, updateFamiliaContracteDTO);
            return await response.ToResponse<int>();
        }
    }
}
