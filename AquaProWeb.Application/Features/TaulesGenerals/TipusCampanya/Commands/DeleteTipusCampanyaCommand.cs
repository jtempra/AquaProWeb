using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Commands
{
    public class DeleteTipusCampanyaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusCampanyaCommandHandler : IRequestHandler<DeleteTipusCampanyaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusCampanyaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusCampanyaCommand Request, CancellationToken cancellationToken)
        {
            var tipusCampanyaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusCampanya>().GetByIdAsync(Request.Id);

            if (tipusCampanyaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusCampanya>().DeleteAsync(tipusCampanyaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusCampanya no trobat!");
        }
    }
}
