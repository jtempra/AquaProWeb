using AquaProWeb.Common.Requests.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IPaisService
{
    Task<ResponseWrapper<int>> AddPaisAsync(CreatePaisDTO createPaisDTO);
    Task<ResponseWrapper<int>> DeletePaisAsync(int id);
    Task<ResponseWrapper<List<ReadPaisDTO>>> GetAllPaisosAsync();
    Task<ResponseWrapper<ReadPaisDTO>> GetPaisByIdAsync(int id);
    Task<ResponseWrapper<List<ReadPaisDTO>>> GetPaisosByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdatePaisAsync(UpdatePaisDTO updatePaisDTO);
}