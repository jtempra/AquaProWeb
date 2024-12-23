using AquaProWeb.Common.Requests.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusReclamacioService
{
    Task<ResponseWrapper<int>> AddTipusReclamacioAsync(SaveTipusReclamacioDTO createTipusReclamacioDTO);
    Task<ResponseWrapper<int>> DeleteTipusReclamacioAsync(int id);
    Task<ResponseWrapper<List<ReadTipusReclamacioDTO>>> GetAllTipusReclamacioAsync();
    Task<ResponseWrapper<ReadTipusReclamacioDTO>> GetTipusReclamacioByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusReclamacioAsync(SaveTipusReclamacioDTO updateTipusReclamacioDTO);
}