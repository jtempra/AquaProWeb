
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.UI.EndPoints.TaulesGenerals;
using AquaProWeb.UI.Extensions;
using AquaProWeb.UI.Services.Contracts;
using System.Net.Http.Json;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaTitularService : IMotiuBaixaTitularService
    {
        private readonly HttpClient _httpClient;

        public MotiuBaixaTitularService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMotiuBaixaTitularAsync(SaveMotiuBaixaTitularDTO createMotiuBaixaTitularDTO)
        {
            var response = await _httpClient.PostAsJsonAsync(MotiusBaixaTitularEndPoints.Add, createMotiuBaixaTitularDTO);
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<int>> DeleteMotiuBaixaTitularAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{MotiusBaixaTitularEndPoints.Delete}/{id}");
            return await response.ToResponse<int>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> GetAllMotiusBaixaTitularAsync()
        {
            var response = await _httpClient.GetAsync(MotiusBaixaTitularEndPoints.GetAll);
            return await response.ToResponse<List<ReadMotiuBaixaTitularDTO>>();

        }

        public async Task<ResponseWrapper<ReadMotiuBaixaTitularDTO>> GetMotiuBaixaTitularByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(MotiusBaixaTitularEndPoints.GetById(id));
            return await response.ToResponse<ReadMotiuBaixaTitularDTO>();
        }

        public async Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> GetMotiusBaixaTitularByTextAsync(string text)
        {
            var response = await _httpClient.GetAsync($"MotiusBaixaTitularEndPoints.GetByText/{text}");
            return await response.ToResponse<List<ReadMotiuBaixaTitularDTO>>();

        }

        public async Task<ResponseWrapper<int>> UpdateMotiuBaixaTitularAsync(SaveMotiuBaixaTitularDTO updateMotiuBaixaTitularDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MotiusBaixaTitularEndPoints.Update, updateMotiuBaixaTitularDTO);
            return await response.ToResponse<int>();
        }
    }
}
