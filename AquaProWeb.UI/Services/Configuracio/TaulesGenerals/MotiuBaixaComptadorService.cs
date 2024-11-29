using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaComptadorService 
    {
        private readonly HttpClient _httpClient;

        public MotiuBaixaComptadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMotiuBaixaComptadorAsync(CreateMotiuBaixaComptadorDTO createMotiuBaixaComptadorDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(MotiusBaixaComptadorEndPoints.Add, createMotiuBaixaComptadorDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteMotiuBaixaComptadorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MotiusBaixaComptadorEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> GetAllMotiusBaixaComptadorsAsync()
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadMotiuBaixaComptadorDTO>>();

        }

        public async Task<ResponseWrapper<ReadMotiuBaixaComptadorDTO>> GetMotiuBaixaComptadorByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadMotiuBaixaComptadorDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> GetMotiusBaixaComptadorsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"MotiusBaixaComptadorEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadMotiuBaixaComptadorDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateMotiuBaixaComptadorAsync(UpdateMotiuBaixaComptadorDTO updateMotiuBaixaComptadorDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MotiusBaixaComptadorEndPoints.Update, updateMotiuBaixaComptadorDTO);
            return await response.ToResponse<int>();
        }
    }
}
