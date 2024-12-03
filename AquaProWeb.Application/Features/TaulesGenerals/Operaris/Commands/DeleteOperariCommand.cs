using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Commands
{
    public class DeleteOperariCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteOperariCommandHandler : IRequestHandler<DeleteOperariCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperariCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteOperariCommand Request, CancellationToken cancellationToken)
        {
            var operariDb = await _unitOfWork.ReadRepositoryFor<Operari>().GetByIdAsync(Request.Id);

            if (operariDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Operari>().DeleteAsync(operariDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Operari creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Operari no trobat!");
        }
    }
}
