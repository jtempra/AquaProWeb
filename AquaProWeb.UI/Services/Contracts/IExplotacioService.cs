
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IExplotacioService
    {
        Task<ResponseWrapper<int>> AddExplotacioAsync(CreateExplotacioDTO createExplotacioDTO);
        Task<ResponseWrapper<int>> UpdateExplotacioAsync(UpdateExplotacioDTO updateExplotacioDTO);
        Task<ResponseWrapper<int>> DeleteExplotacioAsync(int id);
        Task<ResponseWrapper<ReadExplotacioDTO>> GetExplotacioByIdAsync(int id);
        Task<ResponseWrapper<List<ReadExplotacioDTO>>> GetAllExplotacionsAsync();
    }
}
