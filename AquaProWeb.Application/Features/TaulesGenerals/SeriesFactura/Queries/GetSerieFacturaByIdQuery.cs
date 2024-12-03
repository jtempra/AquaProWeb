using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Queries
{
    public class GetSerieFacturaByIdQuery : IRequest<ResponseWrapper<ReadSerieFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSerieFacturaByIdQueryHandler : IRequestHandler<GetSerieFacturaByIdQuery, ResponseWrapper<ReadSerieFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSerieFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadSerieFacturaDTO>> Handle(GetSerieFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var serieFacturaDb = await _unitOfWork.ReadRepositoryFor<SerieFactura>().GetByIdAsync(request.Id);

            if (serieFacturaDb is not null)
            {
                var SerieFacturaDTO = serieFacturaDb.Adapt<ReadSerieFacturaDTO>();

                return new ResponseWrapper<ReadSerieFacturaDTO>().Success(SerieFacturaDTO);
            }

            return new ResponseWrapper<ReadSerieFacturaDTO>().Failure("SerieFactura no existeix!");
        }
    }
}
