using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Queries
{
    public class GetTipusFacturaByIdQuery : IRequest<ResponseWrapper<ReadTipusFacturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusFacturaByIdQueryHandler : IRequestHandler<GetTipusFacturaByIdQuery, ResponseWrapper<ReadTipusFacturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusFacturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusFacturaDTO>> Handle(GetTipusFacturaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusFactura>().GetByIdAsync(request.Id);

            if (tipusFacturaDb is not null)
            {
                var TipusFacturaDTO = tipusFacturaDb.Adapt<ReadTipusFacturaDTO>();

                return new ResponseWrapper<ReadTipusFacturaDTO>().Success(TipusFacturaDTO);
            }

            return new ResponseWrapper<ReadTipusFacturaDTO>().Failure("TipusFactura no existeix!");
        }
    }
}
