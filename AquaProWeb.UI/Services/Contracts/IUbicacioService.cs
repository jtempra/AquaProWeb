using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface IUbicacioService
{
    Task<ResponseWrapper<int>> AddUbicacioAsync(SaveUbicacioDTO createUbicacioDTO);
    Task<ResponseWrapper<int>> DeleteUbicacioAsync(int id);
    Task<ResponseWrapper<List<ListUbicacioDTO>>> GetAllUbicacionsAsync();
    Task<ResponseWrapper<ReadUbicacioDTO>> GetUbicacioByIdAsync(int id);
    Task<ResponseWrapper<List<ListUbicacioDTO>>> GetUbicacionsByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateUbicacioAsync(SaveUbicacioDTO updateUbicacioDTO);
}