using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IFamiliaConcepteFacturaService
{
    Task<ResponseWrapper<int>> AddFamiliaConcepteFacturaAsync(CreateFamiliaConcepteFacturaDTO createFamiliaConcepteFacturaDTO);
    Task<ResponseWrapper<int>> DeleteFamiliaConcepteFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> GetAllFamiliesConcepteFacturaAsync();
    Task<ResponseWrapper<ReadFamiliaConcepteFacturaDTO>> GetFamiliaConcepteFacturaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> GetFamiliesConcepteFacturaByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateFamiliaConcepteFacturaAsync(UpdateFamiliaConcepteFacturaDTO updateFamiliaConcepteFacturaDTO);
}