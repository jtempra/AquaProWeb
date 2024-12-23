using AquaProWeb.Common.Requests.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ITipusDocumentService
{
    Task<ResponseWrapper<int>> AddTipusDocumentAsync(SaveTipusDocumentDTO createTipusDocumentDTO);
    Task<ResponseWrapper<int>> DeleteTipusDocumentAsync(int id);
    Task<ResponseWrapper<List<ReadTipusDocumentDTO>>> GetAllTipusDocumentAsync();
    Task<ResponseWrapper<ReadTipusDocumentDTO>> GetTipusDocumentByIdAsync(int id);
    Task<ResponseWrapper<int>> UpdateTipusDocumentAsync(SaveTipusDocumentDTO updateTipusDocumentDTO);
}