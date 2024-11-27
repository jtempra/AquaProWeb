
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICanalCobramentService
    {
        Task<ResponseWrapper<int>> AddCanalCobramentAsync(CreateCanalCobramentDTO createCanalCobramentDTO);
        Task<ResponseWrapper<int>> UpdateCanalCobramentAsync(UpdateCanalCobramentDTO updateCanalCobramentDTO);
        Task<ResponseWrapper<int>> DeleteCanalCobramentAsync(int id);
        Task<ResponseWrapper<ReadCanalCobramentDTO>> GetCanalCobramentByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCanalCobramentDTO>>> GetAllCanalsCobramentAsync();
    }
}
