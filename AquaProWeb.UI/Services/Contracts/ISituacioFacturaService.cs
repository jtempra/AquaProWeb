using AquaProWeb.Common.Requests.TaulesGenerals.SituacioFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ISituacioFacturaService
{
    Task<ResponseWrapper<int>> AddSituacioFacturaAsync(SaveSituacioFacturaDTO createSituacioFacturaDTO);
    Task<ResponseWrapper<int>> DeleteSituacioFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> GetAllSituacionsFacturasAsync();
    Task<ResponseWrapper<ReadSituacioFacturaDTO>> GetSituacioFacturaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> GetSituacionsFacturasByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateSituacioFacturaAsync(SaveSituacioFacturaDTO updateSituacioFacturaDTO);
}