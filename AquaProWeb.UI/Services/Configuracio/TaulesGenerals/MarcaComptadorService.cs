using AquaProWeb.Common.Requests.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MarcaComptadorService : IMarcaComptadorService
    {
        private readonly HttpClient _httpClient;

        public MarcaComptadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMarcaComptadorAsync(SaveMarcaComptadorDTO createMarcaComptadorDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(MarquesComptadorEndPoints.Add, createMarcaComptadorDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteMarcaComptadorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MarquesComptadorEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> GetAllMarcaComptadorsAsync()
        {
            var response = await _httpClient.GetAsync(MarquesComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadMarcaComptadorDTO>>();

        }

        public async Task<ResponseWrapper<ReadMarcaComptadorDTO>> GetMarcaComptadorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MarquesComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadMarcaComptadorDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> GetMarcaComptadorsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"MarquesComptadorEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadMarcaComptadorDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateMarcaComptadorAsync(SaveMarcaComptadorDTO updateMarcaComptadorDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MarquesComptadorEndPoints.Update, updateMarcaComptadorDTO);
            return await response.ToResponse<int>();
        }
    }
}
