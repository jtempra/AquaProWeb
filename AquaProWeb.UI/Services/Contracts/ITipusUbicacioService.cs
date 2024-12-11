using AquaProWeb.Common.Requests.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusUbicacioService
{
    Task<ResponseWrapper<int>> AddTipusUbicacioAsync(CreateTipusUbicacioDTO createTipusUbicacioDTO);
    Task<ResponseWrapper<int>> DeleteTipusUbicacioAsync(int id);
    Task<ResponseWrapper<List<ReadTipusUbicacioDTO>>> GetAllTipusUbicacioAsync();
    Task<ResponseWrapper<ReadTipusUbicacioDTO>> GetTipusUbicacioByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusUbicacioAsync(UpdateTipusUbicacioDTO updateTipusUbicacioDTO);
}