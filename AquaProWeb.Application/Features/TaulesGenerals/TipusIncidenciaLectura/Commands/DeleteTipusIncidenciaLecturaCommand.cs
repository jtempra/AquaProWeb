using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Commands
{
    public class DeleteTipusIncidenciaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusIncidenciaLecturaCommandHandler : IRequestHandler<DeleteTipusIncidenciaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusIncidenciaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusIncidenciaLecturaCommand Request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaLecturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().GetByIdAsync(Request.Id);

            if (tipusIncidenciaLecturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().DeleteAsync(tipusIncidenciaLecturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Lectura esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaLectura no trobat!");
        }
    }
}
