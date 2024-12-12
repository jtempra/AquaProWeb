using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompte.Commands
{
    public class UpdateMotiuBaixaCompteCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateMotiuBaixaCompteDTO UpdateMotiuBaixaCompte { get; set; }
    }

    public class UpdateMotiuBaixaCompteCommandHandler : IRequestHandler<UpdateMotiuBaixaCompteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotiuBaixaCompteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateMotiuBaixaCompteCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var motiuBaixaCompteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByIdAsync(request.UpdateMotiuBaixaCompte.Id);

            if (motiuBaixaCompteDb is not null)
            {
                request.UpdateMotiuBaixaCompte.Adapt(motiuBaixaCompteDb);

                await _unitOfWork.WriteRepositoryFor<MotiuBaixaCompte>().UpdateAsync(motiuBaixaCompteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(motiuBaixaCompteDb.Id, "Motiu de baixa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El motiu de baixa de Compte no existeix!");

        }
    }
}
