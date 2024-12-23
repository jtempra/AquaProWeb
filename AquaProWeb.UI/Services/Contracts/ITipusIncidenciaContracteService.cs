using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusIncidenciaContracteService
{
    Task<ResponseWrapper<int>> AddTipusIncidenciaContracteAsync(SaveTipusIncidenciaContracteDTO createTipusIncidenciaContracteDTO);
    Task<ResponseWrapper<int>> DeleteTipusIncidenciaContracteAsync(int id);
    Task<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>> GetAllTipusIncidenciaContracteAsync();
    Task<ResponseWrapper<ReadTipusIncidenciaContracteDTO>> GetTipusIncidenciaContracteByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusIncidenciaContracteAsync(SaveTipusIncidenciaContracteDTO updateTipusIncidenciaContracteDTO);
}