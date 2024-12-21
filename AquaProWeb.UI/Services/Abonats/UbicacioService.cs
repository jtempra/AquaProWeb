
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.Abonats;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Abonats
{
    public class UbicacioService : IUbicacioService
    {
        private readonly HttpClient _httpClient;

        public UbicacioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddUbicacioAsync(CreateUbicacioDTO createUbicacioDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(UbicacionsEndPoints.Add, createUbicacioDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteUbicacioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{UbicacionsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadUbicacioDTO>>> GetAllUbicacionsAsync()
        {
            var response = await _httpClient.GetAsync(UbicacionsEndPoints.GetAll);
            return await response.ToResponse<List<ReadUbicacioDTO>>();

        }

        public async Task<ResponseWrapper<ReadUbicacioDTO>> GetUbicacioByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(UbicacionsEndPoints.GetById(id));
            return await response.ToResponse<ReadUbicacioDTO>();
        }

        public async Task<ResponseWrapper<List<ReadUbicacioDTO>>> GetUbicacionsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"PuntsSubministramentEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadUbicacioDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateUbicacioAsync(UpdateUbicacioDTO updateUbicacioDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(UbicacionsEndPoints.Update, updateUbicacioDTO);
            return await response.ToResponse<int>();
        }
    }
}
