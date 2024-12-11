using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Commands
{
    public class DeleteTipusReclamacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusReclamacioCommandHandler : IRequestHandler<DeleteTipusReclamacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusReclamacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusReclamacioCommand Request, CancellationToken cancellationToken)
        {
            var tipusReclamacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusReclamacio>().GetByIdAsync(Request.Id);

            if (tipusReclamacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusReclamacio>().DeleteAsync(tipusReclamacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusReclamacio no trobat!");
        }
    }
}
