using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Commands
{
    public class CreateZonaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveZonaUbicacioDTO CreateZonaUbicacio { get; set; }
    }

    public class CreateZonaUbicacioCommandHandler : IRequestHandler<CreateZonaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateZonaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateZonaUbicacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var zonaUbicacio = request.CreateZonaUbicacio.Adapt<ZonaUbicacio>();

            await _unitOfWork.WriteRepositoryFor<ZonaUbicacio>().AddAsync(zonaUbicacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(zonaUbicacio.Id, "ZonaUbicacio creada correctament!");
        }
    }
}
