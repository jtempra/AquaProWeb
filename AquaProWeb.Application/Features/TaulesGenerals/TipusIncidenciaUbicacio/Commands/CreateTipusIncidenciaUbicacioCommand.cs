using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Commands
{
    public class CreateTipusIncidenciaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusIncidenciaUbicacioDTO CreateTipusIncidenciaUbicacio { get; set; }
    }

    public class CreateTipusIncidenciaUbicacioCommandHandler : IRequestHandler<CreateTipusIncidenciaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusIncidenciaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusIncidenciaUbicacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusIncidenciaUbicacio = request.CreateTipusIncidenciaUbicacio.Adapt<Domain.Entities.TipusIncidenciaUbicacio>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().AddAsync(tipusIncidenciaUbicacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusIncidenciaUbicacio.Id, "TipusIncidenciaUbicacio creat correctament!");
        }
    }
}
