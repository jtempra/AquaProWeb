using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Commands
{
    public class UpdateTipusIncidenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusIncidenciaClientDTO UpdateTipusIncidenciaClient { get; set; }
    }

    public class UpdateTipusIncidenciaClientCommandHandler : IRequestHandler<UpdateTipusIncidenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusIncidenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusIncidenciaClientCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusIncidenciaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaClient>().GetByIdAsync(request.UpdateTipusIncidenciaClient.Id);

            if (tipusIncidenciaClientDb is not null)
            {
                request.UpdateTipusIncidenciaClient.Adapt(tipusIncidenciaClientDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaClient>().UpdateAsync(tipusIncidenciaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusIncidenciaClientDb.Id, "TipusIncidenciaClient actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaClient no existeix!");

        }
    }
}
