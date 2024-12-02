using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IMotiuBaixaTitularService
{
    Task<ResponseWrapper<int>> AddMotiuBaixaTitularAsync(CreateMotiuBaixaTitularDTO createMotiuBaixaTitularDTO);
    Task<ResponseWrapper<int>> DeleteMotiuBaixaTitularAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> GetAllMotiusBaixaTitularAsync();
    Task<ResponseWrapper<ReadMotiuBaixaTitularDTO>> GetMotiuBaixaTitularByIdAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> GetMotiusBaixaTitularByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateMotiuBaixaTitularAsync(UpdateMotiuBaixaTitularDTO updateMotiuBaixaTitularDTO);
}