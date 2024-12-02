using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Commands
{
    public class DeleteCanalCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCanalCobramentCommandHandler : IRequestHandler<DeleteCanalCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCanalCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteCanalCobramentCommand Request, CancellationToken cancellationToken)
        {
            var canalCobramentDb = await _unitOfWork.ReadRepositoryFor<CanalCobrament>().GetByIdAsync(Request.Id);

            if (canalCobramentDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<CanalCobrament>().DeleteAsync(canalCobramentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Canal de cobrament no trobat!");
        }
    }
}
