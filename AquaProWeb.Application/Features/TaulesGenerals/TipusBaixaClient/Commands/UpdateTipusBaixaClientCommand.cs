using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Commands
{
    public class UpdateTipusBaixaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusBaixaClientDTO UpdateTipusBaixaClient { get; set; }
    }

    public class UpdateTipusBaixaClientCommandHandler : IRequestHandler<UpdateTipusBaixaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusBaixaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusBaixaClientCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusBaixaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusBaixaClient>().GetByIdAsync(request.UpdateTipusBaixaClient.Id);

            if (tipusBaixaClientDb is not null)
            {
                request.UpdateTipusBaixaClient.Adapt(tipusBaixaClientDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusBaixaClient>().UpdateAsync(tipusBaixaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusBaixaClientDb.Id, "TipusBaixaClient actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusBaixaClient no existeix!");

        }
    }
}
