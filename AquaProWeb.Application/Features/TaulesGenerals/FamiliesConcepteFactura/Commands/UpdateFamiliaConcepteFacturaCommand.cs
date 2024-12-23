using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class UpdateFamiliaConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveFamiliaConcepteFacturaDTO UpdateFamiliaConcepteFactura { get; set; }
    }

    public class UpdateFamiliaConcepteFacturaCommandHandler : IRequestHandler<UpdateFamiliaConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFamiliaConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateFamiliaConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var familiaConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<FamiliaConcepteFactura>().GetByIdAsync(request.UpdateFamiliaConcepteFactura.Id);

            if (familiaConcepteFacturaDb is not null)
            {
                request.UpdateFamiliaConcepteFactura.Adapt(familiaConcepteFacturaDb);

                await _unitOfWork.WriteRepositoryFor<FamiliaConcepteFactura>().UpdateAsync(familiaConcepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(familiaConcepteFacturaDb.Id, "Empresa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Empresa no existeix!");

        }
    }
}
