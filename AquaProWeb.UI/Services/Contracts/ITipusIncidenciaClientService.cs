using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusIncidenciaClientService
{
    Task<ResponseWrapper<int>> AddTipusIncidenciaClientAsync(CreateTipusIncidenciaClientDTO createTipusIncidenciaClientDTO);
    Task<ResponseWrapper<int>> DeleteTipusIncidenciaClientAsync(int id);
    Task<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>> GetAllTipusIncidenciaClientAsync();
    Task<ResponseWrapper<ReadTipusIncidenciaClientDTO>> GetTipusIncidenciaClientByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusIncidenciaClientAsync(UpdateTipusIncidenciaClientDTO updateTipusIncidenciaClientDTO);
}