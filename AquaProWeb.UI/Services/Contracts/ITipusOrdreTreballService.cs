using AquaProWeb.Common.Requests.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusOrdreTreballService
{
    Task<ResponseWrapper<int>> AddTipusOrdreTreballAsync(CreateTipusOrdreTreballDTO createTipusOrdreTreballDTO);
    Task<ResponseWrapper<int>> DeleteTipusOrdreTreballAsync(int id);
    Task<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>> GetAllTipusOrdreTreballAsync();
    Task<ResponseWrapper<ReadTipusOrdreTreballDTO>> GetTipusOrdreTreballByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusOrdreTreballAsync(UpdateTipusOrdreTreballDTO updateTipusOrdreTreballDTO);
}