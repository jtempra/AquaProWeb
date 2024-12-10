using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Commands
{
    public class CreateTipusOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusOrdreTreballDTO CreateTipusOrdreTreball { get; set; }
    }

    public class CreateTipusOrdreTreballCommandHandler : IRequestHandler<CreateTipusOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusOrdreTreballCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusOrdreTreball = request.CreateTipusOrdreTreball.Adapt<Domain.Entities.TipusOrdreTreball>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusOrdreTreball>().AddAsync(tipusOrdreTreball);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusOrdreTreball.Id, "TipusOrdreTreball creat correctament!");
        }
    }
}
