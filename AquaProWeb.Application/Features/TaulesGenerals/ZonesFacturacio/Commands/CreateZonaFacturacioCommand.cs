using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Commands
{
    public class CreateZonaFacturacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveZonaFacturacioDTO CreateZonaFacturacio { get; set; }
    }

    public class CreateZonaFacturacioCommandHandler : IRequestHandler<CreateZonaFacturacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateZonaFacturacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateZonaFacturacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var zonaFacturacio = request.CreateZonaFacturacio.Adapt<ZonaFacturacio>();

            await _unitOfWork.WriteRepositoryFor<ZonaFacturacio>().AddAsync(zonaFacturacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(zonaFacturacio.Id, "ZonaFacturacio creada correctament!");
        }
    }
}
