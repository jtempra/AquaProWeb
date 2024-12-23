using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Commands
{
    public class UpdateTipusIncidenciaTecnicaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusIncidenciaTecnicaDTO UpdateTipusIncidenciaTecnica { get; set; }
    }

    public class UpdateTipusIncidenciaTecnicaCommandHandler : IRequestHandler<UpdateTipusIncidenciaTecnicaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusIncidenciaTecnicaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusIncidenciaTecnicaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusIncidenciaTecnicaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().GetByIdAsync(request.UpdateTipusIncidenciaTecnica.Id);

            if (tipusIncidenciaTecnicaDb is not null)
            {
                request.UpdateTipusIncidenciaTecnica.Adapt(tipusIncidenciaTecnicaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().UpdateAsync(tipusIncidenciaTecnicaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusIncidenciaTecnicaDb.Id, "TipusIncidenciaTecnica actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaTecnica no existeix!");

        }
    }
}
