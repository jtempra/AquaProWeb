using AquaProWeb.Common.Requests.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusClientService
{
    Task<ResponseWrapper<int>> AddTipusClientAsync(SaveTipusClientDTO createTipusClientDTO);
    Task<ResponseWrapper<int>> DeleteTipusClientAsync(int id);
    Task<ResponseWrapper<List<ReadTipusClientDTO>>> GetAllTipusClientsAsync();
    Task<ResponseWrapper<ReadTipusClientDTO>> GetTipusClientByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusClientAsync(SaveTipusClientDTO updateTipusClientDTO);
}