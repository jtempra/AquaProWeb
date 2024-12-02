using AquaProWeb.Common.Requests.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IUsContracteService
{
    Task<ResponseWrapper<int>> AddUsContracteAsync(CreateUsContracteDTO createUsContracteDTO);
    Task<ResponseWrapper<int>> DeleteUsContracteAsync(int id);
    Task<ResponseWrapper<List<ReadUsContracteDTO>>> GetAllZonesCarrerAsync();
    Task<ResponseWrapper<ReadUsContracteDTO>> GetUsContracteByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateUsContracteAsync(UpdateUsContracteDTO updateUsContracteDTO);
}