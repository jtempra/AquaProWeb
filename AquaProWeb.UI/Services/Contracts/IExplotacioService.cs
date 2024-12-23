
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IExplotacioService
    {
        Task<ResponseWrapper<int>> AddExplotacioAsync(SaveExplotacioDTO createExplotacioDTO);
        Task<ResponseWrapper<int>> UpdateExplotacioAsync(SaveExplotacioDTO updateExplotacioDTO);
        Task<ResponseWrapper<int>> DeleteExplotacioAsync(int id);
        Task<ResponseWrapper<ReadExplotacioDTO>> GetExplotacioByIdAsync(int id);
        Task<ResponseWrapper<List<ReadExplotacioDTO>>> GetAllExplotacionsAsync();
    }
}
