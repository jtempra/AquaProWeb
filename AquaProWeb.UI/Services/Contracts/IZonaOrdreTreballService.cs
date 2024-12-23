using AquaProWeb.Common.Requests.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IZonaOrdreTreballService
{
    Task<ResponseWrapper<int>> AddZonaOrdreTreballAsync(SaveZonaOrdreTreballDTO createZonaOrdreTreballDTO);
    Task<ResponseWrapper<int>> DeleteZonaOrdreTreballAsync(int id);
    Task<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>> GetAllZonesCarrerAsync();
    Task<ResponseWrapper<ReadZonaOrdreTreballDTO>> GetZonaOrdreTreballByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateZonaOrdreTreballAsync(SaveZonaOrdreTreballDTO updateZonaOrdreTreballDTO);
}