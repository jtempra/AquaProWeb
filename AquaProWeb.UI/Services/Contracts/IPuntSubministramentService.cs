using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IPuntSubministramentService
{
    Task<ResponseWrapper<int>> AddPuntSubministramentAsync(CreatePuntSubministramentDTO createPuntSubministramentDTO);
    Task<ResponseWrapper<int>> DeletePuntSubministramentAsync(int id);
    Task<ResponseWrapper<List<ReadPuntSubministramentDTO>>> GetAllPuntsSubministramentAsync();
    Task<ResponseWrapper<ReadPuntSubministramentDTO>> GetPuntSubministramentByIdAsync(int id);
    Task<ResponseWrapper<List<ReadPuntSubministramentDTO>>> GetPuntsSubministramentByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdatePuntSubministramentAsync(UpdatePuntSubministramentDTO updatePuntSubministramentDTO);
}