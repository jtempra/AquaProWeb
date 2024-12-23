using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusIncidenciaLecturaService
{
    Task<ResponseWrapper<int>> AddTipusIncidenciaLecturaAsync(SaveTipusIncidenciaLecturaDTO createTipusIncidenciaLecturaDTO);
    Task<ResponseWrapper<int>> DeleteTipusIncidenciaLecturaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>> GetAllTipusIncidenciaLecturaAsync();
    Task<ResponseWrapper<ReadTipusIncidenciaLecturaDTO>> GetTipusIncidenciaLecturaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusIncidenciaLecturaAsync(SaveTipusIncidenciaLecturaDTO updateTipusIncidenciaLecturaDTO);
}