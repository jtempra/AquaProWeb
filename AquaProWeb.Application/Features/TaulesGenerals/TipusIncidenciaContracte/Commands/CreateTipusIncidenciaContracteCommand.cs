using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Commands
{
    public class CreateTipusIncidenciaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusIncidenciaContracteDTO CreateTipusIncidenciaContracte { get; set; }
    }

    public class CreateTipusIncidenciaContracteCommandHandler : IRequestHandler<CreateTipusIncidenciaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusIncidenciaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusIncidenciaContracteCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusIncidenciaContracte = request.CreateTipusIncidenciaContracte.Adapt<Domain.Entities.TipusIncidenciaContracte>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().AddAsync(tipusIncidenciaContracte);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusIncidenciaContracte.Id, "TipusIncidenciaContracte creat correctament!");
        }
    }
}
