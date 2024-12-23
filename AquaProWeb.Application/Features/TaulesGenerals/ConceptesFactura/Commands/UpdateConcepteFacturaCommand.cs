using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Commands
{
    public class UpdateConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveConcepteFacturaDTO UpdateConcepteFactura { get; set; }
    }

    public class UpdateConcepteFacturaCommandHandler : IRequestHandler<UpdateConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var concepteFacturaDb = await _unitOfWork.ReadRepositoryFor<ConcepteFactura>().GetByIdAsync(request.UpdateConcepteFactura.Id);

            if (concepteFacturaDb is not null)
            {
                request.UpdateConcepteFactura.Adapt(concepteFacturaDb);

                await _unitOfWork.WriteRepositoryFor<ConcepteFactura>().UpdateAsync(concepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(concepteFacturaDb.Id, "Concepte Factura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Concepte Factura no existeix!");

        }
    }
}
