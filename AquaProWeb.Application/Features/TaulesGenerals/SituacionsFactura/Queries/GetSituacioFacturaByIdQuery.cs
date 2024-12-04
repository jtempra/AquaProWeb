using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Queries
{
    public class GetSituacioFacturaByIdQuery : IRequest<ResponseWrapper<ReadSituacioFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSituacioFacturaByIdQueryHandler : IRequestHandler<GetSituacioFacturaByIdQuery, ResponseWrapper<ReadSituacioFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacioFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadSituacioFacturaDTO>> Handle(GetSituacioFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var situacioFacturaDb = await _unitOfWork.ReadRepositoryFor<SituacioFactura>().GetByIdAsync(request.Id);

            if (situacioFacturaDb is not null)
            {
                var SituacioFacturaDTO = situacioFacturaDb.Adapt<ReadSituacioFacturaDTO>();

                return new ResponseWrapper<ReadSituacioFacturaDTO>().Success(SituacioFacturaDTO);
            }

            return new ResponseWrapper<ReadSituacioFacturaDTO>().Failure("SituacioFactura no existeix!");
        }
    }
}
