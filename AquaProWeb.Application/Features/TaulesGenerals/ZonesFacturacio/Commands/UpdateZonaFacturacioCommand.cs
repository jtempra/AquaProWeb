using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Commands
{
    public class UpdateZonaFacturacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveZonaFacturacioDTO UpdateZonaFacturacio { get; set; }
    }

    public class UpdateZonaFacturacioCommandHandler : IRequestHandler<UpdateZonaFacturacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateZonaFacturacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateZonaFacturacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var zonaFacturacioDb = await _unitOfWork.ReadRepositoryFor<ZonaFacturacio>().GetByIdAsync(request.UpdateZonaFacturacio.Id);

            if (zonaFacturacioDb is not null)
            {
                request.UpdateZonaFacturacio.Adapt(zonaFacturacioDb);

                await _unitOfWork.WriteRepositoryFor<ZonaFacturacio>().UpdateAsync(zonaFacturacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaFacturacioDb.Id, "Zona Facturacio actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La Zona Facturacio no existeix!");

        }
    }
}
