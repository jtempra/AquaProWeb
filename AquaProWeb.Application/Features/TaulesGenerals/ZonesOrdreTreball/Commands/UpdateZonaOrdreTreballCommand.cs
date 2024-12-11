using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Commands
{
    public class UpdateZonaOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateZonaOrdreTreballDTO UpdateZonaOrdreTreball { get; set; }
    }

    public class UpdateZonaOrdreTreballCommandHandler : IRequestHandler<UpdateZonaOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateZonaOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateZonaOrdreTreballCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var zonaOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<ZonaOrdreTreball>().GetByIdAsync(request.UpdateZonaOrdreTreball.Id);

            if (zonaOrdreTreballDb is not null)
            {
                request.UpdateZonaOrdreTreball.Adapt(zonaOrdreTreballDb);

                await _unitOfWork.WriteRepositoryFor<ZonaOrdreTreball>().UpdateAsync(zonaOrdreTreballDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaOrdreTreballDb.Id, "Zona OrdreTreball actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La Zona OrdreTreball no existeix!");

        }
    }
}
