using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Commands
{
    public class DeleteTipusOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusOrdreTreballCommandHandler : IRequestHandler<DeleteTipusOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusOrdreTreballCommand Request, CancellationToken cancellationToken)
        {
            var tipusOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusOrdreTreball>().GetByIdAsync(Request.Id);

            if (tipusOrdreTreballDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusOrdreTreball>().DeleteAsync(tipusOrdreTreballDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusOrdreTreball no trobat!");
        }
    }
}
