using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Queries
{
    public class GetSeriesFacturaQuery : IRequest<ResponseWrapper<List<ReadSerieFacturaDTO>>>
    {
    }

    public class GetSeriesFacturaQueryHandler : IRequestHandler<GetSeriesFacturaQuery, ResponseWrapper<List<ReadSerieFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSeriesFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSerieFacturaDTO>>> Handle(GetSeriesFacturaQuery request, CancellationToken cancellationToken)
        {
            var serieFacturaDb = await _unitOfWork.ReadRepositoryFor<SerieFactura>().GetAllAsync();

            if (serieFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSerieFacturaDTO>>().Success(serieFacturaDb.Adapt<List<ReadSerieFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadSerieFacturaDTO>>().Failure("No hi han SeriesFactura!");
        }
    }
}
