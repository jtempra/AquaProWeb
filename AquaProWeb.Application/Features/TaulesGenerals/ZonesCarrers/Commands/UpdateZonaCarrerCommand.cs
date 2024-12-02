using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Commands
{
    public class UpdateZonaCarrerCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateZonaCarrerDTO UpdateZonaCarrer { get; set; }
    }

    public class UpdateZonaCarrerCommandHandler : IRequestHandler<UpdateZonaCarrerCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateZonaCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateZonaCarrerCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var zonaCarrerDb = await _unitOfWork.ReadRepositoryFor<ZonaCarrers>().GetByIdAsync(request.UpdateZonaCarrer.Id);

            if (zonaCarrerDb is not null)
            {
                request.UpdateZonaCarrer.Adapt(zonaCarrerDb);

                await _unitOfWork.WriteRepositoryFor<ZonaCarrers>().UpdateAsync(zonaCarrerDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaCarrerDb.Id, "Zona Carrer actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La Zona Carrer no existeix!");

        }
    }
}
