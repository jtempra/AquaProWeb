using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Commands
{
    public class UpdateSituacioRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveSituacioRebutDTO UpdateSituacioRebut { get; set; }
    }

    public class UpdateSituacioRebutCommandHandler : IRequestHandler<UpdateSituacioRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSituacioRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateSituacioRebutCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var situacioRebutDb = await _unitOfWork.ReadRepositoryFor<SituacioRebut>().GetByIdAsync(request.UpdateSituacioRebut.Id);

            if (situacioRebutDb is not null)
            {
                request.UpdateSituacioRebut.Adapt(situacioRebutDb);

                await _unitOfWork.WriteRepositoryFor<SituacioRebut>().UpdateAsync(situacioRebutDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(situacioRebutDb.Id, "SituacioRebut actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SituacioRebut no existeix!");

        }
    }
}
