using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IFamiliaContracteService
{
    Task<ResponseWrapper<int>> AddFamiliaContracteAsync(SaveFamiliaContracteDTO createFamiliaContracteDTO);
    Task<ResponseWrapper<int>> DeleteFamiliaContracteAsync(int id);
    Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> GetAllFamiliesContracteAsync();
    Task<ResponseWrapper<ReadFamiliaContracteDTO>> GetFamiliaContracteByIdAsync(int id);
    Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> GetFamiliesContracteByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateFamiliaContracteAsync(SaveFamiliaContracteDTO updateFamiliaContracteDTO);
}