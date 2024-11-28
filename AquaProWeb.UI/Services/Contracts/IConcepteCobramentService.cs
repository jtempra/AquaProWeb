using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IConcepteCobramentService
{
    Task<ResponseWrapper<int>> AddConcepteCobramentAsync(CreateConcepteCobramentDTO createConcepteCobramentDTO);
    Task<ResponseWrapper<int>> DeleteConcepteCobramentAsync(int id);
    Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> GetAllConceptesCobramentAsync();
    Task<ResponseWrapper<ReadConcepteCobramentDTO>> GetConcepteCobramentByIdAsync(int id);
    Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> GetConceptesCobramentByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateConcepteCobramentAsync(UpdateConcepteCobramentDTO updateConcepteCobramentDTO);
}