using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Commands
{
    public class CreateRutaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveRutaLecturaDTO CreateRutaLectura { get; set; }
    }

    public class CreateRutaLecturaCommandHandler : IRequestHandler<CreateRutaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRutaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateRutaLecturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var rutaLectura = request.CreateRutaLectura.Adapt<RutaLectura>();

            await _unitOfWork.WriteRepositoryFor<RutaLectura>().AddAsync(rutaLectura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(rutaLectura.Id, "Població creada correctament!");
        }
    }
}
