using AquaProWeb.Common.Requests.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IZonaUbicacioService
{
    Task<ResponseWrapper<int>> AddZonaUbicacioAsync(SaveZonaUbicacioDTO createZonaUbicacioDTO);
    Task<ResponseWrapper<int>> DeleteZonaUbicacioAsync(int id);
    Task<ResponseWrapper<List<ReadZonaUbicacioDTO>>> GetAllZonesUbicacioAsync();
    Task<ResponseWrapper<ReadZonaUbicacioDTO>> GetZonaUbicacioByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateZonaUbicacioAsync(SaveZonaUbicacioDTO updateZonaUbicacioDTO);
}