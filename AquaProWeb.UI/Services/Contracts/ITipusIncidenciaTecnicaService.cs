using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusIncidenciaTecnicaService
{
    Task<ResponseWrapper<int>> AddTipusIncidenciaTecnicaAsync(CreateTipusIncidenciaTecnicaDTO createTipusIncidenciaTecnicaDTO);
    Task<ResponseWrapper<int>> DeleteTipusIncidenciaTecnicaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>> GetAllTipusIncidenciaTecnicaAsync();
    Task<ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>> GetTipusIncidenciaTecnicaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusIncidenciaTecnicaAsync(UpdateTipusIncidenciaTecnicaDTO updateTipusIncidenciaTecnicaDTO);
}