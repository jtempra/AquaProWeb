using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Commands
{
    public class CreateZonaCarrerCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateZonaCarrerDTO CreateZonaCarrer { get; set; }
    }

    public class CreateZonaCarrerCommandHandler : IRequestHandler<CreateZonaCarrerCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateZonaCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateZonaCarrerCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var zonaCarrer = request.CreateZonaCarrer.Adapt<ZonaCarrers>();

            await _unitOfWork.WriteRepositoryFor<ZonaCarrers>().AddAsync(zonaCarrer);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(zonaCarrer.Id, "ZonaCarrer creada correctament!");
        }
    }
}
