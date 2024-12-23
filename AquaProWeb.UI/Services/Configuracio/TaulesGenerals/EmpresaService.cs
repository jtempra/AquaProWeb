using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _httpClient;

        public EmpresaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddEmpresaAsync(SaveEmpresaDTO createEmpresaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(EmpresesEndPoints.Add, createEmpresaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteEmpresaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{EmpresesEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadEmpresaDTO>>> GetAllEmpresesAsync()
        {
            var response = await _httpClient.GetAsync(EmpresesEndPoints.GetAll);
            return await response.ToResponse<List<ReadEmpresaDTO>>();

        }

        public async Task<ResponseWrapper<ReadEmpresaDTO>> GetEmpresaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(EmpresesEndPoints.GetById(id));
            return await response.ToResponse<ReadEmpresaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadEmpresaDTO>>> GetEmpresesByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"EmpresesEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadEmpresaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateEmpresaAsync(SaveEmpresaDTO updateEmpresaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(EmpresesEndPoints.Update, updateEmpresaDTO);
            return await response.ToResponse<int>();
        }
    }
}
