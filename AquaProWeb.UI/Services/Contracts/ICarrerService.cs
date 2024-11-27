using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts
{
    public interface ICarrerService
    {
        Task<ResponseWrapper<int>> AddCarrerAsync(CreateCarrerDTO createCarrerDTO);
        Task<ResponseWrapper<int>> UpdateCarrerAsync(UpdateCarrerDTO updateCarrerDTO);
        Task<ResponseWrapper<int>> DeleteCarrerAsync(int id);
        Task<ResponseWrapper<ReadCarrerDTO>> GetCarrerByIdAsync(int id);
        Task<ResponseWrapper<List<ReadCarrerDTO>>> GetAllCarrersAsync();
        Task<ResponseWrapper<List<ReadCarrerDTO>>> GetCarrersByTextAsync(string text);
    }
}
