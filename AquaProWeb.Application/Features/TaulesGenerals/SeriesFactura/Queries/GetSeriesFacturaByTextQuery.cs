using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Queries
{
    public class GetSeriesFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadSerieFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetSeriesFacturaByTextQueryHandler : IRequestHandler<GetSeriesFacturaByTextQuery, ResponseWrapper<List<ReadSerieFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeriesFacturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> Handle(GetSeriesFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var serieFacturaDb = await _unitOfWork.ReadRepositoryFor<SerieFactura>().GetByTextAsync(request.Text);

            if (serieFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSerieFacturaDTO>>().Success(serieFacturaDb.Adapt<List<ReadSerieFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadSerieFacturaDTO>>().Failure("No s'han trobat SeriesFactura!");
        }
    }
}
