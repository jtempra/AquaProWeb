using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IMotiuBaixaContacteService
{
    Task<ResponseWrapper<int>> AddMotiuBaixaContacteAsync(SaveMotiuBaixaContacteDTO createMotiuBaixaContacteDTO);
    Task<ResponseWrapper<int>> DeleteMotiuBaixaContacteAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetAllMotiusBaixaContacteAsync();
    Task<ResponseWrapper<ReadMotiuBaixaContacteDTO>> GetMotiuBaixaContacteByIdAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> GetMotiusBaixaContacteByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateMotiuBaixaContacteAsync(SaveMotiuBaixaContacteDTO updateMotiuBaixaContacteDTO);
}