using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Commands
{
    public class UpdateTipusConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusConcepteFacturaDTO UpdateTipusConcepteFactura { get; set; }
    }

    public class UpdateTipusConcepteFacturaCommandHandler : IRequestHandler<UpdateTipusConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusConcepteFactura>().GetByIdAsync(request.UpdateTipusConcepteFactura.Id);

            if (tipusConcepteFacturaDb is not null)
            {
                request.UpdateTipusConcepteFactura.Adapt(tipusConcepteFacturaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusConcepteFactura>().UpdateAsync(tipusConcepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusConcepteFacturaDb.Id, "TipusConcepteFactura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusConcepteFactura no existeix!");

        }
    }
}
