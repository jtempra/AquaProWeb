using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Commands
{
    public class UpdateTipusFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusFacturaDTO UpdateTipusFactura { get; set; }
    }

    public class UpdateTipusFacturaCommandHandler : IRequestHandler<UpdateTipusFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusFactura>().GetByIdAsync(request.UpdateTipusFactura.Id);

            if (tipusFacturaDb is not null)
            {
                request.UpdateTipusFactura.Adapt(tipusFacturaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusFactura>().UpdateAsync(tipusFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusFacturaDb.Id, "TipusFactura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusFactura no existeix!");

        }
    }
}
