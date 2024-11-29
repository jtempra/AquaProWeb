using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class SerieFacturaService 
    {
        private readonly HttpClient _httpClient;

        public SerieFacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddSerieFacturaAsync(CreateSerieFacturaDTO createSerieFacturaDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(SeriesFacturaEndPoints.Add, createSerieFacturaDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteSerieFacturaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{SeriesFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> GetAllSeriesFacturasAsync()
        {
            var response = await _httpClient.GetAsync(SeriesFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadSerieFacturaDTO>>();

        }

        public async Task<ResponseWrapper<ReadSerieFacturaDTO>> GetSerieFacturaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(SeriesFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadSerieFacturaDTO>();
        }

        public async Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> GetSeriesFacturasByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"SeriesFacturaEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadSerieFacturaDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateSerieFacturaAsync(UpdateSerieFacturaDTO updateSerieFacturaDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(SeriesFacturaEndPoints.Update, updateSerieFacturaDTO);
            return await response.ToResponse<int>();
        }
    }
}
