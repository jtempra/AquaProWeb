using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Commands
{
    public class DeleteRutaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteRutaLecturaCommandHandler : IRequestHandler<DeleteRutaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRutaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteRutaLecturaCommand Request, CancellationToken cancellationToken)
        {
            var rutaLecturaDb = await _unitOfWork.ReadRepositoryFor<RutaLectura>().GetByIdAsync(Request.Id);

            if (rutaLecturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<RutaLectura>().DeleteAsync(rutaLecturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(rutaLecturaDb.Id, "Ruta Lectura esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Ruta Lectura no trobada!");
        }
    }
}
