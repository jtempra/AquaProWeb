using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Commands
{
    public class UpdateTipusIncidenciaLecturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusIncidenciaLecturaDTO UpdateTipusIncidenciaLectura { get; set; }
    }

    public class UpdateTipusIncidenciaLecturaCommandHandler : IRequestHandler<UpdateTipusIncidenciaLecturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusIncidenciaLecturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusIncidenciaLecturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusIncidenciaLecturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().GetByIdAsync(request.UpdateTipusIncidenciaLectura.Id);

            if (tipusIncidenciaLecturaDb is not null)
            {
                request.UpdateTipusIncidenciaLectura.Adapt(tipusIncidenciaLecturaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().UpdateAsync(tipusIncidenciaLecturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusIncidenciaLecturaDb.Id, "TipusIncidenciaLectura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaLectura no existeix!");

        }
    }
}
