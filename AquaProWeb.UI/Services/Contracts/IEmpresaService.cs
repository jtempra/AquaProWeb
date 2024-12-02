using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IEmpresaService
{
    Task<ResponseWrapper<int>> AddEmpresaAsync(CreateEmpresaDTO createEmpresaDTO);
    Task<ResponseWrapper<int>> DeleteEmpresaAsync(int id);
    Task<ResponseWrapper<List<ReadEmpresaDTO>>> GetAllEmpresesAsync();
    Task<ResponseWrapper<ReadEmpresaDTO>> GetEmpresaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadEmpresaDTO>>> GetEmpresesByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateEmpresaAsync(UpdateEmpresaDTO updateEmpresaDTO);
}