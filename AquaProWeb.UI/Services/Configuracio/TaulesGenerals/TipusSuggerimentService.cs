using AquaProWeb.Common.Requests.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class TipusSuggerimentService 
    {
        private readonly HttpClient _httpClient;

        public TipusSuggerimentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddTipusSuggerimentAsync(CreateTipusSuggerimentDTO createTipusSuggerimentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(TipusSuggerimentsEndPoints.Add, createTipusSuggerimentDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteTipusSuggerimentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{TipusSuggerimentsEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadTipusSuggerimentDTO>>> GetAllTipusSuggerimentAsync()
        {
            var response = await _httpClient.GetAsync(TipusSuggerimentsEndPoints.GetAll);
            return await response.ToResponse<List<ReadTipusSuggerimentDTO>>();

        }

        public async Task<ResponseWrapper<ReadTipusSuggerimentDTO>> GetTipusSuggerimentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(TipusSuggerimentsEndPoints.GetById(id));
            return await response.ToResponse<ReadTipusSuggerimentDTO>();
        }

        public async Task<ResponseWrapper<int>> UpdateTipusSuggerimentAsync(UpdateTipusSuggerimentDTO updateTipusSuggerimentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(TipusSuggerimentsEndPoints.Update, updateTipusSuggerimentDTO);
            return await response.ToResponse<int>();
        }
    }
}
