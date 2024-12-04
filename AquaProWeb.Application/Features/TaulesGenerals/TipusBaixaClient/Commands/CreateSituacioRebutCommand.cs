using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClient;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Commands
{
    public class CreateTipusBaixaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusBaixaClientDTO CreateTipusBaixaClient { get; set; }
    }

    public class CreateTipusBaixaClientCommandHandler : IRequestHandler<CreateTipusBaixaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusBaixaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusBaixaClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusBaixaClient = request.CreateTipusBaixaClient.Adapt<Domain.Entities.TipusBaixaClient>();

            await _unitOfWork.WriteRepositoryFor<TipusBaixaClient>().AddAsync(tipusBaixaClient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(TipusBaixaClient.Id, "TipusBaixaClient creat correctament!");
        }
    }
}
