using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusConcepteFacturaService
{
    Task<ResponseWrapper<int>> AddTipusConcepteFacturaAsync(CreateTipusConcepteFacturaDTO createTipusConcepteFacturaDTO);
    Task<ResponseWrapper<int>> DeleteTipusConcepteFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>> GetAllTipusConcepteFacturaAsync();
    Task<ResponseWrapper<ReadTipusConcepteFacturaDTO>> GetTipusConcepteFacturaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusConcepteFacturaAsync(UpdateTipusConcepteFacturaDTO updateTipusConcepteFacturaDTO);
}