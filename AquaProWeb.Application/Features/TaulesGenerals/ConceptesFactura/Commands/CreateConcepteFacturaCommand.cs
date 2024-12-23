using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Commands
{
    public class CreateConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveConcepteFacturaDTO CreateConcepteFactura { get; set; }
    }

    public class CreateConcepteFacturaCommandHandler : IRequestHandler<CreateConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var concepteFactura = request.CreateConcepteFactura.Adapt<ConcepteFactura>();

            await _unitOfWork.WriteRepositoryFor<ConcepteFactura>().AddAsync(concepteFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(concepteFactura.Id, "Concepte Factura creat correctament!");
        }
    }
}
