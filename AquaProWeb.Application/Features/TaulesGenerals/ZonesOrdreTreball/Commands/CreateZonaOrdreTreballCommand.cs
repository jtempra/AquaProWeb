using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Commands
{
    public class CreateZonaOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveZonaOrdreTreballDTO CreateZonaOrdreTreball { get; set; }
    }

    public class CreateZonaOrdreTreballCommandHandler : IRequestHandler<CreateZonaOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateZonaOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateZonaOrdreTreballCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var zonaOrdreTreball = request.CreateZonaOrdreTreball.Adapt<ZonaOrdreTreball>();

            await _unitOfWork.WriteRepositoryFor<ZonaOrdreTreball>().AddAsync(zonaOrdreTreball);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(zonaOrdreTreball.Id, "ZonaOrdreTreball creada correctament!");
        }
    }
}
