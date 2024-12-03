using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class DeleteFamiliaConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteFamiliaConcepteCommandHandler : IRequestHandler<DeleteFamiliaConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFamiliaConcepteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteFamiliaConcepteFacturaCommand Request, CancellationToken cancellationToken)
        {
            var familiaConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<FamiliaConcepteFactura>().GetByIdAsync(Request.Id);

            if (familiaConcepteFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<FamiliaConcepteFactura>().DeleteAsync(familiaConcepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(familiaConcepteFacturaDb.Id, "Empresa esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Empresa no trobat!");
        }
    }
}
