using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Commands
{
    public class UpdateRutaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveRutaLecturaDTO UpdateRutaLectura { get; set; }
    }

    public class UpdateRutaLecturaCommandHandler : IRequestHandler<UpdateRutaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRutaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateRutaLecturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var rutaLecturaDb = await _unitOfWork.ReadRepositoryFor<RutaLectura>().GetByIdAsync(request.UpdateRutaLectura.Id);

            if (rutaLecturaDb is not null)
            {
                request.UpdateRutaLectura.Adapt(rutaLecturaDb);

                await _unitOfWork.WriteRepositoryFor<RutaLectura>().UpdateAsync(rutaLecturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(rutaLecturaDb.Id, "RutaLectura actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La RutaLectura no existeix!");

        }
    }
}
