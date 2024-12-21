using AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IRutaLecturaService
{
    Task<ResponseWrapper<int>> AddRutaLecturaAsync(CreateRutaLecturaDTO createRutaLecturaDTO);
    Task<ResponseWrapper<int>> DeleteRutaLecturaAsync(int id);
    Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> GetAllRutesLecturaAsync();
    Task<ResponseWrapper<ReadRutaLecturaDTO>> GetRutaLecturaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> GetRutesLecturaByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateRutaLecturaAsync(UpdateRutaLecturaDTO updateRutaLecturaDTO);
}