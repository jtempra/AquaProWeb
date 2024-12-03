using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.Parametrens.Commands
{
    public class DeleteParametreCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteParametreCommandHandler : IRequestHandler<DeleteParametreCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParametreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteParametreCommand Request, CancellationToken cancellationToken)
        {
            var parametreDb = await _unitOfWork.ReadRepositoryFor<Parametre>().GetByIdAsync(Request.Id);

            if (parametreDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Parametre>().DeleteAsync(parametreDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Parametre esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Paràmetre no trobada!");
        }
    }
}
