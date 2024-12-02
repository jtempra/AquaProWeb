using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IMotiuBaixaCompteService
{
    Task<ResponseWrapper<int>> AddMotiuBaixaCompteAsync(CreateMotiuBaixaCompteDTO createMotiuBaixaCompteDTO);
    Task<ResponseWrapper<int>> DeleteMotiuBaixaCompteAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> GetAllMotiusBaixaComptadorsAsync();
    Task<ResponseWrapper<ReadMotiuBaixaCompteDTO>> GetMotiuBaixaCompteByIdAsync(int id);
    Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> GetMotiusBaixaComptadorsByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateMotiuBaixaCompteAsync(UpdateMotiuBaixaCompteDTO updateMotiuBaixaCompteDTO);
}