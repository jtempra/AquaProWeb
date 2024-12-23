using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Commands
{
    public class CreateTipusClientCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusClientDTO CreateTipusClient { get; set; }
    }

    public class CreateTipusClientCommandHandler : IRequestHandler<CreateTipusClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusClient = request.CreateTipusClient.Adapt<Domain.Entities.TipusClient>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusClient>().AddAsync(tipusClient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusClient.Id, "TipusClient creat correctament!");
        }
    }
}
