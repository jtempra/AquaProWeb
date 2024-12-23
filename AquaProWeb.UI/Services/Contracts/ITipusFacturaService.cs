using AquaProWeb.Common.Requests.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusFacturaService
{
    Task<ResponseWrapper<int>> AddTipusFacturaAsync(SaveTipusFacturaDTO createTipusFacturaDTO);
    Task<ResponseWrapper<int>> DeleteTipusFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusFacturaDTO>>> GetAllTipusFacturaAsync();
    Task<ResponseWrapper<ReadTipusFacturaDTO>> GetTipusFacturaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusFacturaAsync(SaveTipusFacturaDTO updateTipusFacturaDTO);
}