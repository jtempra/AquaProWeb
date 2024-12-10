using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Commands
{
    public class CreateTipusIncidenciaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusIncidenciaLecturaDTO CreateTipusIncidenciaLectura { get; set; }
    }

    public class CreateTipusIncidenciaLecturaCommandHandler : IRequestHandler<CreateTipusIncidenciaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusIncidenciaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusIncidenciaLecturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusIncidenciaLectura = request.CreateTipusIncidenciaLectura.Adapt<Domain.Entities.TipusIncidenciaLectura>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().AddAsync(tipusIncidenciaLectura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusIncidenciaLectura.Id, "TipusIncidenciaLectura creat correctament!");
        }
    }
}
