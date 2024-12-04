using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Commands
{
    public class DeleteSituacioRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSituacioRebutCommandHandler : IRequestHandler<DeleteSituacioRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSituacioRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteSituacioRebutCommand Request, CancellationToken cancellationToken)
        {
            var situacioRebutDb = await _unitOfWork.ReadRepositoryFor<SituacioRebut>().GetByIdAsync(Request.Id);

            if (situacioRebutDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<SituacioRebut>().DeleteAsync(situacioRebutDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "SituacioRebut creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SituacioRebut no trobat!");
        }
    }
}
