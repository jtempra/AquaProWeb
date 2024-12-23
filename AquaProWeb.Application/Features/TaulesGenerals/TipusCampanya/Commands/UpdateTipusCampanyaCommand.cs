using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Commands
{
    public class UpdateTipusCampanyaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusCampanyaDTO UpdateTipusCampanya { get; set; }
    }

    public class UpdateTipusCampanyaCommandHandler : IRequestHandler<UpdateTipusCampanyaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusCampanyaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusCampanyaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusCampanyaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusCampanya>().GetByIdAsync(request.UpdateTipusCampanya.Id);

            if (tipusCampanyaDb is not null)
            {
                request.UpdateTipusCampanya.Adapt(tipusCampanyaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusCampanya>().UpdateAsync(tipusCampanyaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusCampanyaDb.Id, "TipusCampanya actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusCampanya no existeix!");

        }
    }
}
