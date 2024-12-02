using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaCompteService : IMotiuBaixaCompteService
    {
        private readonly HttpClient _httpClient;

        public MotiuBaixaCompteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMotiuBaixaCompteAsync(CreateMotiuBaixaCompteDTO createMotiuBaixaCompteDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(MotiusBaixaComptadorEndPoints.Add, createMotiuBaixaCompteDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteMotiuBaixaCompteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MotiusBaixaComptadorEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> GetAllMotiusBaixaComptadorsAsync()
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetAll);
            return await response.ToResponse<List<ReadMotiuBaixaCompteDTO>>();

        }

        public async Task<ResponseWrapper<ReadMotiuBaixaCompteDTO>> GetMotiuBaixaCompteByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MotiusBaixaComptadorEndPoints.GetById(id));
            return await response.ToResponse<ReadMotiuBaixaCompteDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> GetMotiusBaixaComptadorsByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"MotiusBaixaComptadorEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadMotiuBaixaCompteDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateMotiuBaixaCompteAsync(UpdateMotiuBaixaCompteDTO updateMotiuBaixaCompteDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MotiusBaixaComptadorEndPoints.Update, updateMotiuBaixaCompteDTO);
            return await response.ToResponse<int>();
        }
    }
}
