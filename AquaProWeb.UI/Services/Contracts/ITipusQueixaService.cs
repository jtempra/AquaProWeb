using AquaProWeb.Common.Requests.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusQueixaService
{
    Task<ResponseWrapper<int>> AddTipusQueixaAsync(CreateTipusQueixaDTO createTipusQueixaDTO);
    Task<ResponseWrapper<int>> DeleteTipusQueixaAsync(int id);
    Task<ResponseWrapper<List<ReadTipusQueixaDTO>>> GetAllTipusQueixaAsync();
    Task<ResponseWrapper<ReadTipusQueixaDTO>> GetTipusQueixaByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusQueixaAsync(UpdateTipusQueixaDTO updateTipusQueixaDTO);
}