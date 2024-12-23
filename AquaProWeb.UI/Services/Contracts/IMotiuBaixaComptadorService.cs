using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IMotiuBaixaComptadorService
{
    Task<ResponseWrapper<int>> AddMotiuBaixaComptadorAsync(SaveMotiuBaixaComptadorDTO createMotiuBaixaComptadorDTO);
    Task<ResponseWrapper<int>> DeleteMotiuBaixaComptadorAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> GetAllMotiusBaixaComptadorsAsync();
    Task<ResponseWrapper<ReadMotiuBaixaComptadorDTO>> GetMotiuBaixaComptadorByIdAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> GetMotiusBaixaComptadorsByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateMotiuBaixaComptadorAsync(SaveMotiuBaixaComptadorDTO updateMotiuBaixaComptadorDTO);
}