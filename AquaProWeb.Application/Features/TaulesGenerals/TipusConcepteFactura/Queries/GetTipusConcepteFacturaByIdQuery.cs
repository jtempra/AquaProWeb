using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Queries
{
    public class GetTipusConcepteFacturaByIdQuery : IRequest<ResponseWrapper<ReadTipusConcepteFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusConcepteFacturaByIdQueryHandler : IRequestHandler<GetTipusConcepteFacturaByIdQuery, ResponseWrapper<ReadTipusConcepteFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusConcepteFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusConcepteFacturaDTO>> Handle(GetTipusConcepteFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusConcepteFactura>().GetByIdAsync(request.Id);

            if (tipusConcepteFacturaDb is not null)
            {
                var TipusConcepteFacturaDTO = tipusConcepteFacturaDb.Adapt<ReadTipusConcepteFacturaDTO>();

                return new ResponseWrapper<ReadTipusConcepteFacturaDTO>().Success(TipusConcepteFacturaDTO);
            }

            return new ResponseWrapper<ReadTipusConcepteFacturaDTO>().Failure("TipusConcepteFactura no existeix!");
        }
    }
}
