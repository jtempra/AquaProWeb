using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IConcepteFacturaService
{
    Task<ResponseWrapper<int>> AddConcepteFacturaAsync(CreateConcepteFacturaDTO createConcepteFacturaDTO);
    Task<ResponseWrapper<int>> DeleteConcepteFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> GetAllConceptesFacturaAsync();
    Task<ResponseWrapper<ReadConcepteFacturaDTO>> GetConcepteFacturaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> GetConceptesFacturaByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateConcepteFacturaAsync(UpdateConcepteFacturaDTO updateConcepteFacturaDTO);
}