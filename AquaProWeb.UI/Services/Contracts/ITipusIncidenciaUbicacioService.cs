using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusIncidenciaUbicacioService
{
    Task<ResponseWrapper<int>> AddTipusIncidenciaUbicacioAsync(SaveTipusIncidenciaUbicacioDTO createTipusIncidenciaUbicacioDTO);
    Task<ResponseWrapper<int>> DeleteTipusIncidenciaUbicacioAsync(int id);
    Task<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>> GetAllTipusIncidenciaUbicacioAsync();
    Task<ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>> GetTipusIncidenciaUbicacioByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusIncidenciaUbicacioAsync(SaveTipusIncidenciaUbicacioDTO updateTipusIncidenciaUbicacioDTO);
}