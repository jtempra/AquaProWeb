using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Commands
{
    public class UpdateTipusComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusComptadorDTO UpdateTipusComptador { get; set; }
    }

    public class UpdateTipusComptadorCommandHandler : IRequestHandler<UpdateTipusComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusComptadorCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusComptadorDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusComptador>().GetByIdAsync(request.UpdateTipusComptador.Id);

            if (tipusComptadorDb is not null)
            {
                request.UpdateTipusComptador.Adapt(tipusComptadorDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusComptador>().UpdateAsync(tipusComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusComptadorDb.Id, "TipusComptador actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusComptador no existeix!");

        }
    }
}
