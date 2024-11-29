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
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals
{
    public class MotiuBaixaTitularService 
    {
        private readonly HttpClient _httpClient;

        public MotiuBaixaTitularService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseWrapper<int>> AddMotiuBaixaTitularAsync(CreateMotiuBaixaTitularDTO createMotiuBaixaTitularDTO)
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

        public async Task<ResponseWrapper<int>> UpdateMotiuBaixaTitularAsync(UpdateMotiuBaixaTitularDTO updateMotiuBaixaTitularDTO)
        {
            var response = await _httpClient.PutAsJsonAsync(MotiusBaixaTitularEndPoints.Update, updateMotiuBaixaTitularDTO);
            return await response.ToResponse<int>();
        }
    }
}
