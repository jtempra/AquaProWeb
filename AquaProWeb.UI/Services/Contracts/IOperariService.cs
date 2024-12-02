using AquaProWeb.Common.Requests.TaulesGenerals.Operaris;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IOperariService
{
    Task<ResponseWrapper<int>> AddOperariAsync(CreateOperariDTO createOperariDTO);
    Task<ResponseWrapper<int>> DeleteOperariAsync(int id);
    Task<ResponseWrapper<List<ReadOperariDTO>>> GetAllOperarisAsync();
    Task<ResponseWrapper<ReadOperariDTO>> GetOperariByIdAsync(int id);
    Task<ResponseWrapper<List<ReadOperariDTO>>> GetOperarisByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateOperariAsync(UpdateOperariDTO updateOperariDTO);
}