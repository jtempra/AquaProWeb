using AquaProWeb.Common.Requests.Parametres;
using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface IParametreService
    {
        Task<ResponseWrapper<int>> AddParametreAsync(SaveParametreDTO createParametreDTO);
        Task<ResponseWrapper<int>> DeleteParametreAsync(int id);
        Task<ResponseWrapper<List<ReadParametreDTO>>> GetAllParametresAsync();
        Task<ResponseWrapper<ReadParametreDTO>> GetParametreByIdAsync(int id);
        Task<ResponseWrapper<List<ReadParametreDTO>>> GetParametresByTextAsync(string text);
        Task<ResponseWrapper<int>> UpdateParametreAsync(SaveParametreDTO updateParametreDTO);
    }

}
