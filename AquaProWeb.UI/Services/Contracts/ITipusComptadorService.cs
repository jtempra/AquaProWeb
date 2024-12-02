using AquaProWeb.Common.Requests.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusComptadorService
{
    Task<ResponseWrapper<int>> AddTipusComptadorAsync(CreateTipusComptadorDTO createTipusComptadorDTO);
    Task<ResponseWrapper<int>> DeleteTipusComptadorAsync(int id);
    Task<ResponseWrapper<List<ReadTipusComptadorDTO>>> GetAllTipusComptadorAsync();
    Task<ResponseWrapper<ReadTipusComptadorDTO>> GetTipusComptadorByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusComptadorAsync(UpdateTipusComptadorDTO updateTipusComptadorDTO);
}