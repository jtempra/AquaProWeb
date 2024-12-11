using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Commands
{
    public class UpdateZonaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateZonaUbicacioDTO UpdateZonaUbicacio { get; set; }
    }

    public class UpdateZonaUbicacioCommandHandler : IRequestHandler<UpdateZonaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateZonaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateZonaUbicacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var zonaUbicacioDb = await _unitOfWork.ReadRepositoryFor<ZonaUbicacio>().GetByIdAsync(request.UpdateZonaUbicacio.Id);

            if (zonaUbicacioDb is not null)
            {
                request.UpdateZonaUbicacio.Adapt(zonaUbicacioDb);

                await _unitOfWork.WriteRepositoryFor<ZonaUbicacio>().UpdateAsync(zonaUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaUbicacioDb.Id, "Zona Ubicacio actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La Zona Ubicacio no existeix!");

        }
    }
}
