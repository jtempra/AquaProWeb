
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICompteTransferenciaClientService
    {
        Task<ResponseWrapper<int>> AddCompteTransferenciaClientAsync(CreateCompteRemesaBancDTO createCompteTransferenciaClientDTO);
        Task<ResponseWrapper<int>> UpdateCompteTransferenciaClientAsync(UpdateCompteRemesaBancDTO updateCompteTransferenciaClientDTO);
        Task<ResponseWrapper<int>> DeleteCompteTransferenciaClientAsync(int id);
        Task<ResponseWrapper<ReadCompteTransferenciaClientDTO>> GetCompteTransferenciaClientByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetAllComptesTransferenciaClientAsync();
        Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> GetComptesTransferenciaClientByTextAsync(string text);
    }
}
