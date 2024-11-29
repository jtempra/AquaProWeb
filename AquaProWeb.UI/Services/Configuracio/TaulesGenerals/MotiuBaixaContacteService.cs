using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaContacteService 
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

        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetAllMotiusBaixaComptadorsAsync()
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadMotiuBaixaContacteDTO>>();

        }

        public async Task<ResponseWrapper<ReadMotiuBaixaContacteDTO>> GetMotiuBaixaContacteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadMotiuBaixaContacteDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetMotiusBaixaComptadorsByTextAsync(string text)
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
