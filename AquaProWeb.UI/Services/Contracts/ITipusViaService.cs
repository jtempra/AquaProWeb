using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ITipusViaService
    {
        Task<ResponseWrapper<int>> AddTipusViaAsync(CreateTipusViaDTO createTipusViaDTO);
        Task<ResponseWrapper<int>> UpdateTipusViaAsync(UpdateTipusViaDTO updateTipusViaDTO);
        Task<ResponseWrapper<int>> DeleteTipusViaAsync(int id);
        Task<ResponseWrapper<ReadTipusViaDTO>> GetTipusViaByIdAsync(int id);
        Task<ResponseWrapper<List<ReadTipusViaDTO>>> GetAllTipusViaAsync();
    }
}
