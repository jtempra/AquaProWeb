
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IPoblacioService
    {
        Task<ResponseWrapper<int>> AddPoblacioAsync(SavePoblacioDTO createPoblacioDTO);
        Task<ResponseWrapper<int>> UpdatePoblacioAsync(SavePoblacioDTO updatePoblacioDTO);
        Task<ResponseWrapper<int>> DeletePoblacioAsync(int id);
        Task<ResponseWrapper<ReadPoblacioDTO>> GetPoblacioByIdAsync(int id);
        Task<ResponseWrapper<List<ReadPoblacioDTO>>> GetAllPoblacionsAsync();
        Task<ResponseWrapper<List<ReadPoblacioDTO>>> GetPoblacionsByTextAsync(string text);
    }
}
