using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Commands
{
    public class CreateTipusComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusComptadorDTO CreateTipusComptador { get; set; }
    }

    public class CreateTipusComptadorCommandHandler : IRequestHandler<CreateTipusComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusComptadorCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusComptador = request.CreateTipusComptador.Adapt<Domain.Entities.TipusComptador>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusComptador>().AddAsync(tipusComptador);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusComptador.Id, "TipusComptador creat correctament!");
        }
    }
}
