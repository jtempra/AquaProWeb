using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.Explotacions.Commands
{
    public class DeleteExplotacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteExplotacioCommandHandler : IRequestHandler<DeleteExplotacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExplotacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteExplotacioCommand Request, CancellationToken cancellationToken)
        {
            var explotacioDb = await _unitOfWork.ReadRepositoryFor<Explotacio>().GetByIdAsync(Request.Id);

            if (explotacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Explotacio>().DeleteAsync(explotacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Explotacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Explotació no trobada!");
        }
    }
}
