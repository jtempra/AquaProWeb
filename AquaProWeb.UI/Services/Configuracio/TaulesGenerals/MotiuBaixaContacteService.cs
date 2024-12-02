using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaContacteService : IMotiuBaixaContacteService
    {
        private readonly HttpClient _httpClient;

        public MotiuBaixaContacteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMotiuBaixaContacteAsync(CreateMotiuBaixaContacteDTO createMotiuBaixaContacteDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(MotiusBaixaContacteEndPoints.Add, createMotiuBaixaContacteDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteMotiuBaixaContacteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MotiusBaixaComptadorEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetAllMotiusBaixaContacteAsync()
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadMotiuBaixaContacteDTO>>();

        }

        public async Task<ResponseWrapper<ReadMotiuBaixaContacteDTO>> GetMotiuBaixaContacteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadMotiuBaixaContacteDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetMotiusBaixaContacteByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"MotiusBaixaComptadorEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadMotiuBaixaContacteDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateMotiuBaixaContacteAsync(UpdateMotiuBaixaContacteDTO updateMotiuBaixaContacteDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MotiusBaixaComptadorEndPoints.Update, updateMotiuBaixaContacteDTO);
            return await response.ToResponse<int>();
        }
    }
}
