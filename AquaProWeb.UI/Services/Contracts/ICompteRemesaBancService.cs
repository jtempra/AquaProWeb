
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesRemesaBanc;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICompteRemesaBancService
    {
        Task<ResponseWrapper<int>> AddCompteRemesaBancAsync(CreateCompteRemesaBancDTO createCompteRemesaBancDTO);
        Task<ResponseWrapper<int>> UpdateCompteRemesaBancAsync(UpdateCompteRemesaBancDTO updateCompteRemesaBancDTO);
        Task<ResponseWrapper<int>> DeleteCompteRemesaBancAsync(int id);
        Task<ResponseWrapper<ReadCompteRemesaBancDTO>> GetCompteRemesaBancByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> GetAllComptesRemesaBancAsync();
        Task<ResponseWrapper<List<ReadCompteRemesaBancDTO>>> GetComptesRemesaBancByTextAsync(string text);
    }
}
