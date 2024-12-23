using AquaProWeb.Common.Requests.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class UsContracteService : IUsContracteService
    {
        private readonly HttpClient _httpClient;

        public UsContracteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddUsContracteAsync(SaveUsContracteDTO createUsContracteDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(UsosContracteEndPoints.Add, createUsContracteDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteUsContracteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{UsosContracteEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadUsContracteDTO>>> GetAllZonesCarrerAsync()
        {
            var response = await _httpClient.GetAsync(UsosContracteEndPoints.GetAll);
            return await response.ToResponse<List<ReadUsContracteDTO>>();

        }

        public async Task<ResponseWrapper<ReadUsContracteDTO>> GetUsContracteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(UsosContracteEndPoints.GetById(id));
            return await response.ToResponse<ReadUsContracteDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateUsContracteAsync(SaveUsContracteDTO updateUsContracteDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(UsosContracteEndPoints.Update, updateUsContracteDTO);
            return await response.ToResponse<int>();
        }
    }
}
