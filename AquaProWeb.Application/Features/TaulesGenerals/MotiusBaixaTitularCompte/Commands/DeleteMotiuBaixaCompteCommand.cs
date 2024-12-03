using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompte.Commands
{
    public class DeleteMotiuBaixaCompteCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMotiuBaixaCompteCommandHandler : IRequestHandler<DeleteMotiuBaixaCompteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotiuBaixaCompteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteMotiuBaixaCompteCommand Request, CancellationToken cancellationToken)
        {
            var motiuBaixaCompteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByIdAsync(Request.Id);

            if (motiuBaixaCompteDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<MotiuBaixaCompte>().DeleteAsync(motiuBaixaCompteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Motiu baixa Compte no trobat!");
        }
    }
}
