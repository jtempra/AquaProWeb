using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IZonaCarrerService
    {
        Task<ResponseWrapper<int>> AddZonaCarrerAsync(CreateZonaCarrerDTO createZonaCarrerDTO);
        Task<ResponseWrapper<int>> UpdateZonaCarrerAsync(UpdateZonaCarrerDTO updateZonaCarrerDTO);
        Task<ResponseWrapper<int>> DeleteZonaCarrerAsync(int id);
        Task<ResponseWrapper<ReadZonaCarrerDTO>> GetZonaCarrerByIdAsync(int id);
        Task<ResponseWrapper<List<ReadZonaCarrerDTO>>> GetAllZonesCarrerAsync();
    }
}
