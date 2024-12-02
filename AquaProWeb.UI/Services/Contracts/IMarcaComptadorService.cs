using AquaProWeb.Common.Requests.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Configuracio.TaulesGenerals;

public interface IMarcaComptadorService
{
    Task<ResponseWrapper<int>> AddMarcaComptadorAsync(CreateMarcaComptadorDTO createMarcaComptadorDTO);
    Task<ResponseWrapper<int>> DeleteMarcaComptadorAsync(int id);
    Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> GetAllMarcaComptadorsAsync();
    Task<ResponseWrapper<ReadMarcaComptadorDTO>> GetMarcaComptadorByIdAsync(int id);
    Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> GetMarcaComptadorsByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateMarcaComptadorAsync(UpdateMarcaComptadorDTO updateMarcaComptadorDTO);
}