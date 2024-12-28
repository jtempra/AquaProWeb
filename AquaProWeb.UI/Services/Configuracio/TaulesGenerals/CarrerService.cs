using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class CarrerService : ICarrerService
    {
        private readonly HttpClient _httpClient;

        public CarrerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddCarrerAsync(SaveCarrerDTO createCarrerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(CarrersEndPoints.Add, createCarrerDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteCarrerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{CarrersEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> GetAllCarrersAsync()
        {
            var response = await _httpClient.GetAsync(CarrersEndPoints.GetAll);
            return await response.ToResponse<List<ReadCarrerDTO>>();

        }

        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> GetCarrersByIdPoblacioAsync(int idPoblacio)
        {
            var response = await _httpClient.GetAsync(CarrersEndPoints.GetByIdPoblacio(idPoblacio));
            return await response.ToResponse<List<ReadCarrerDTO>>();
        }
        public async Task<ResponseWrapper<ReadCarrerDTO>> GetCarrerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(CarrersEndPoints.GetById(id));
            return await response.ToResponse<ReadCarrerDTO>();
        }

        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> GetCarrersByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"CarrersEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadCarrerDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateCarrerAsync(SaveCarrerDTO updateCarrerDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(CarrersEndPoints.Update, updateCarrerDTO);
            return await response.ToResponse<int>();
        }
    }
}
