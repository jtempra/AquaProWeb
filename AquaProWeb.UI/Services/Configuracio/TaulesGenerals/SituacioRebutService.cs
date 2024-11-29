using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioRebut;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class SituacioRebutService 
    {
        private readonly HttpClient _httpClient;

        public SituacioRebutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddSituacioRebutAsync(CreateSituacioRebutDTO createSituacioRebutDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(SituacionsRebutEndPoints.Add, createSituacioRebutDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteSituacioRebutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{SituacionsRebutEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadSituacioRebutDTO>>> GetAllSituacionsFacturasAsync()
        {
            var response = await _httpClient.GetAsync(SituacionsRebutEndPoints.GetAll);
            return await response.ToResponse<List<ReadSituacioRebutDTO>>();

        }

        public async Task<ResponseWrapper<ReadSituacioRebutDTO>> GetSituacioRebutByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(SituacionsRebutEndPoints.GetById(id));
            return await response.ToResponse<ReadSituacioRebutDTO>();
        }

        public async Task<ResponseWrapper<List<ReadSituacioRebutDTO>>> GetSituacionsFacturasByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"SituacionsRebutEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadSituacioRebutDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateSituacioRebutAsync(UpdateSituacioRebutDTO updateSituacioRebutDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(SituacionsRebutEndPoints.Update, updateSituacioRebutDTO);
            return await response.ToResponse<int>();
        }
    }
}
