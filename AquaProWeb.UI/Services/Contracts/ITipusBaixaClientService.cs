using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusBaixaClientService
{
    Task<ResponseWrapper<int>> AddTipusBaixaClientAsync(SaveTipusBaixaClientDTO createTipusBaixaClientDTO);
    Task<ResponseWrapper<int>> DeleteTipusBaixaClientAsync(int id);
    Task<ResponseWrapper<List<ReadTipusBaixaClientDTO>>> GetAllTipusBaixaClientAsync();
    Task<ResponseWrapper<ReadTipusBaixaClientDTO>> GetTipusBaixaClientByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusBaixaClientAsync(SaveTipusBaixaClientDTO updateTipusBaixaClientDTO);
}