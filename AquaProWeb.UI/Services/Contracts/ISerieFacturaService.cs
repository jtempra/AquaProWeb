using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;

namespace AquaProWeb.UI.Services.Contracts;

public interface ISerieFacturaService
{
    Task<ResponseWrapper<int>> AddSerieFacturaAsync(CreateSerieFacturaDTO createSerieFacturaDTO);
    Task<ResponseWrapper<int>> DeleteSerieFacturaAsync(int id);
    Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> GetAllSeriesFacturasAsync();
    Task<ResponseWrapper<ReadSerieFacturaDTO>> GetSerieFacturaByIdAsync(int id);
    Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> GetSeriesFacturasByTextAsync(string text);
    Task<ResponseWrapper<int>> UpdateSerieFacturaAsync(UpdateSerieFacturaDTO updateSerieFacturaDTO);
}