﻿using AquaProWeb.Common.Requests.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class SerieRebutService : ISerieRebutService
    {
        private readonly HttpClient _httpClient;

        public SerieRebutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddSerieRebutAsync(SaveSerieRebutDTO createSerieRebutDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(SeriesFacturaEndPoints.Add, createSerieRebutDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteSerieRebutAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{SeriesFacturaEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadSerieRebutDTO>>> GetAllSeriesFacturasAsync()
        {
            var response = await _httpClient.GetAsync(SeriesFacturaEndPoints.GetAll);
            return await response.ToResponse<List<ReadSerieRebutDTO>>();

        }

        public async Task<ResponseWrapper<ReadSerieRebutDTO>> GetSerieRebutByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(SeriesFacturaEndPoints.GetById(id));
            return await response.ToResponse<ReadSerieRebutDTO>();
        }

        public async Task<ResponseWrapper<List<ReadSerieRebutDTO>>> GetSeriesFacturasByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"SeriesFacturaEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadSerieRebutDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateSerieRebutAsync(SaveSerieRebutDTO updateSerieRebutDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(SeriesFacturaEndPoints.Update, updateSerieRebutDTO);
            return await response.ToResponse<int>();
        }
    }
}
