using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Commands
{
    public class DeletePaisCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePaisCommandHandler : IRequestHandler<DeletePaisCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePaisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeletePaisCommand Request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<Pais>().GetByIdAsync(Request.Id);

            if (paisDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Pais>().DeleteAsync(paisDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Pais creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Pais no trobat!");
        }
    }
}
