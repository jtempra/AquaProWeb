using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Commands
{
    public class UpdateTipusIncidenciaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusIncidenciaUbicacioDTO UpdateTipusIncidenciaUbicacio { get; set; }
    }

    public class UpdateTipusIncidenciaUbicacioCommandHandler : IRequestHandler<UpdateTipusIncidenciaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusIncidenciaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusIncidenciaUbicacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusIncidenciaUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().GetByIdAsync(request.UpdateTipusIncidenciaUbicacio.Id);

            if (tipusIncidenciaUbicacioDb is not null)
            {
                request.UpdateTipusIncidenciaUbicacio.Adapt(tipusIncidenciaUbicacioDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().UpdateAsync(tipusIncidenciaUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusIncidenciaUbicacioDb.Id, "TipusIncidenciaUbicacio actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaUbicacio no existeix!");

        }
    }
}
