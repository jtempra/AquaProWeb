using AquaProWeb.Common.Requests.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusCampanyaService
{
    Task<ResponseWrapper<int>> AddTipusCampanyaAsync(CreateTipusCampanyaDTO createTipusCampanyaDTO);
    Task<ResponseWrapper<int>> DeleteTipusCampanyaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusCampanyaDTO>>> GetAllTipusCampanyaAsync();
    Task<ResponseWrapper<ReadTipusCampanyaDTO>> GetTipusCampanyaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusCampanyaAsync(UpdateTipusCampanyaDTO updateTipusCampanyaDTO);
}