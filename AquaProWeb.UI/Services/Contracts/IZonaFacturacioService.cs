using AquaProWeb.Common.Requests.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IZonaFacturacioService
{
    Task<ResponseWrapper<int>> AddZonaFacturacioAsync(SaveZonaFacturacioDTO createZonaFacturacioDTO);
    Task<ResponseWrapper<int>> DeleteZonaFacturacioAsync(int id);
    Task<ResponseWrapper<List<ReadZonaFacturacioDTO>>> GetAllZonesCarrerAsync();
    Task<ResponseWrapper<ReadZonaFacturacioDTO>> GetZonaFacturacioByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateZonaFacturacioAsync(SaveZonaFacturacioDTO updateZonaFacturacioDTO);
}