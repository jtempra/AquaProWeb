
using AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class RutaLecturaService : IRutaLecturaService
    {
        private readonly HttpClient _httpClient;

        public RutaLecturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddRutaLecturaAsync(CreateRutaLecturaDTO createRutaLecturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(RutasLecturaEndPoints.Add, createRutaLecturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteRutaLecturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{RutasLecturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> GetAllRutesLecturaAsync()
        {
            var response = await _httpClient.GetAsync(RutasLecturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadRutaLecturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadRutaLecturaDTO>> GetRutaLecturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(RutasLecturaEndPoints.GetById(id));
            return await response.ToResponse<ReadRutaLecturaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> GetRutesLecturaByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"{RutasLecturaEndPoints.GetByText}/{text}");
            return await response.ToResponse<List<ReadRutaLecturaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateRutaLecturaAsync(UpdateRutaLecturaDTO updateRutaLecturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(RutasLecturaEndPoints.Update, updateRutaLecturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
