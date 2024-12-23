using AquaProWeb.Common.Requests.Abonats.Escomeses;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IEscomesaService
{
    Task<ResponseWrapper<int>> AddEscomesaAsync(SaveEscomesaDTO createEscomesaDTO);
    Task<ResponseWrapper<int>> DeleteEscomesaAsync(int id);
    Task<ResponseWrapper<List<ReadEscomesaDTO>>> GetAllEscomesesAsync();
    Task<ResponseWrapper<ReadEscomesaDTO>> GetEscomesaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadEscomesaDTO>>> GetEscomesesByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateEscomesaAsync(SaveEscomesaDTO updateEscomesaDTO);
}