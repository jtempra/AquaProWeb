using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Commands
{
    public class CreateTipusIncidenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusIncidenciaClientDTO CreateTipusIncidenciaClient { get; set; }
    }

    public class CreateTipusIncidenciaClientCommandHandler : IRequestHandler<CreateTipusIncidenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusIncidenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusIncidenciaClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusIncidenciaClient = request.CreateTipusIncidenciaClient.Adapt<Domain.Entities.TipusIncidenciaClient>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaClient>().AddAsync(tipusIncidenciaClient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusIncidenciaClient.Id, "TipusIncidenciaClient creat correctament!");
        }
    }
}
