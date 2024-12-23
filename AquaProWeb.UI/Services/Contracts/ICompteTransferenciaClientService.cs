using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICompteTransferenciaClientService
    {
        Task<ResponseWrapper<int>> AddCompteTransferenciaClientAsync(SaveCompteTransferenciaClientDTO createCompteTransferenciaClientDTO);
        Task<ResponseWrapper<int>> UpdateCompteTransferenciaClientAsync(SaveCompteTransferenciaClientDTO updateCompteTransferenciaClientDTO);
        Task<ResponseWrapper<int>> DeleteCompteTransferenciaClientAsync(int id);
        Task<ResponseWrapper<ReadCompteTransferenciaClientDTO>> GetCompteTransferenciaClientByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetAllComptesTransferenciaClientAsync();
        Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetComptesTransferenciaClientByTextAsync(string text);
    }
}
