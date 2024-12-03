using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Commands
{
    public class DeleteConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteConcepteFacturaCommandHandler : IRequestHandler<DeleteConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteConcepteFacturaCommand Request, CancellationToken cancellationToken)
        {
            var concepteFacturaDb = await _unitOfWork.ReadRepositoryFor<ConcepteFactura>().GetByIdAsync(Request.Id);

            if (concepteFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ConcepteFactura>().DeleteAsync(concepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(concepteFacturaDb.Id, "Concepte Factura esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Concepte Factura no trobat!");
        }
    }
}
