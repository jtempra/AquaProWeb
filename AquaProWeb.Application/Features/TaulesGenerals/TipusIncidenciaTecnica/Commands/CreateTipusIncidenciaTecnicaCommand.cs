using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Commands
{
    public class CreateTipusIncidenciaTecnicaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusIncidenciaTecnicaDTO CreateTipusIncidenciaTecnica { get; set; }
    }

    public class CreateTipusIncidenciaTecnicaCommandHandler : IRequestHandler<CreateTipusIncidenciaTecnicaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusIncidenciaTecnicaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusIncidenciaTecnicaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusIncidenciaTecnica = request.CreateTipusIncidenciaTecnica.Adapt<Domain.Entities.TipusIncidenciaTecnica>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().AddAsync(tipusIncidenciaTecnica);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusIncidenciaTecnica.Id, "TipusIncidenciaTecnica creat correctament!");
        }
    }
}
