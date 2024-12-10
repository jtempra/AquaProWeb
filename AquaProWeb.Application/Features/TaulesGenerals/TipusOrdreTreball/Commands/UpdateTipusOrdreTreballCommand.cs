using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Commands
{
    public class UpdateTipusOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusOrdreTreballDTO UpdateTipusOrdreTreball { get; set; }
    }

    public class UpdateTipusOrdreTreballCommandHandler : IRequestHandler<UpdateTipusOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusOrdreTreballCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusOrdreTreball>().GetByIdAsync(request.UpdateTipusOrdreTreball.Id);

            if (tipusOrdreTreballDb is not null)
            {
                request.UpdateTipusOrdreTreball.Adapt(tipusOrdreTreballDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusOrdreTreball>().UpdateAsync(tipusOrdreTreballDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusOrdreTreballDb.Id, "TipusOrdreTreball actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusOrdreTreball no existeix!");

        }
    }
}
