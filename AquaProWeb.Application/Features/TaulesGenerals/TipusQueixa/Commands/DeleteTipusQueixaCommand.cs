using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Commands
{
    public class DeleteTipusQueixaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusQueixaCommandHandler : IRequestHandler<DeleteTipusQueixaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusQueixaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusQueixaCommand Request, CancellationToken cancellationToken)
        {
            var tipusQueixaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusQueixa>().GetByIdAsync(Request.Id);

            if (tipusQueixaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusQueixa>().DeleteAsync(tipusQueixaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusQueixa no trobat!");
        }
    }
}
