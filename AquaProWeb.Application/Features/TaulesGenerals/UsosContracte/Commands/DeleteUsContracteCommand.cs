using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Commands
{
    public class DeleteUsContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteUsContracteCommandHandler : IRequestHandler<DeleteUsContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUsContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteUsContracteCommand Request, CancellationToken cancellationToken)
        {
            var UsContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.UsContracte>().GetByIdAsync(Request.Id);

            if (UsContracteDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.UsContracte>().DeleteAsync(UsContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("UsContracte no trobat!");
        }
    }
}
