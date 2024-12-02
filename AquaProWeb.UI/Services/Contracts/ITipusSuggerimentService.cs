using AquaProWeb.Common.Requests.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusSuggerimentService
{
    Task<ResponseWrapper<int>> AddTipusSuggerimentAsync(CreateTipusSuggerimentDTO createTipusSuggerimentDTO);
    Task<ResponseWrapper<int>> DeleteTipusSuggerimentAsync(int id);
    Task<ResponseWrapper<List<ReadTipusSuggerimentDTO>>> GetAllTipusSuggerimentAsync();
    Task<ResponseWrapper<ReadTipusSuggerimentDTO>> GetTipusSuggerimentByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusSuggerimentAsync(UpdateTipusSuggerimentDTO updateTipusSuggerimentDTO);
}