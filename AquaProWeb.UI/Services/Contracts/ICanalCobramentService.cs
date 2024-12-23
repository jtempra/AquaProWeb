
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICanalCobramentService
    {
        Task<ResponseWrapper<int>> AddCanalCobramentAsync(SaveCanalCobramentDTO createCanalCobramentDTO);
        Task<ResponseWrapper<int>> UpdateCanalCobramentAsync(SaveCanalCobramentDTO updateCanalCobramentDTO);
        Task<ResponseWrapper<int>> DeleteCanalCobramentAsync(int id);
        Task<ResponseWrapper<ReadCanalCobramentDTO>> GetCanalCobramentByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCanalCobramentDTO>>> GetAllCanalsCobramentAsync();
    }
}
