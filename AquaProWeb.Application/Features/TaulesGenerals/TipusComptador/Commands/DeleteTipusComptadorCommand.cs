using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Commands
{
    public class DeleteTipusComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusComptadorCommandHandler : IRequestHandler<DeleteTipusComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusComptadorCommand Request, CancellationToken cancellationToken)
        {
            var tipusComptadorDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusComptador>().GetByIdAsync(Request.Id);

            if (tipusComptadorDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusComptador>().DeleteAsync(tipusComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusComptador no trobat!");
        }
    }
}
