using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IZonaCarrerService
    {
        Task<ResponseWrapper<int>> AddZonaCarrerAsync(SaveZonaCarrerDTO createZonaCarrerDTO);
        Task<ResponseWrapper<int>> UpdateZonaCarrerAsync(SaveZonaCarrerDTO updateZonaCarrerDTO);
        Task<ResponseWrapper<int>> DeleteZonaCarrerAsync(int id);
        Task<ResponseWrapper<ReadZonaCarrerDTO>> GetZonaCarrerByIdAsync(int id);
        Task<ResponseWrapper<List<ReadZonaCarrerDTO>>> GetAllZonesCarrerAsync();
    }
}
