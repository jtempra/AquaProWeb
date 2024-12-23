using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Commands
{
    public class UpdateTipusClientCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusClientDTO UpdateTipusClient { get; set; }
    }

    public class UpdateTipusClientCommandHandler : IRequestHandler<UpdateTipusClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusClientCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusClient>().GetByIdAsync(request.UpdateTipusClient.Id);

            if (tipusClientDb is not null)
            {
                request.UpdateTipusClient.Adapt(tipusClientDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusClient>().UpdateAsync(tipusClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusClientDb.Id, "TipusClient actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusClient no existeix!");

        }
    }
}
