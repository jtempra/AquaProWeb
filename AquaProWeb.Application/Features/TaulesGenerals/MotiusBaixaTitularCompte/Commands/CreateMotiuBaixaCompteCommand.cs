using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompte.Commands
{
    public class CreateMotiuBaixaCompteCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateMotiuBaixaCompteDTO CreateMotiuBaixaCompte { get; set; }
    }

    public class CreateMotiuBaixaCompteCommandHandler : IRequestHandler<CreateMotiuBaixaCompteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotiuBaixaCompteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateMotiuBaixaCompteCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var motiuBaixaCompte = request.CreateMotiuBaixaCompte.Adapt<MotiuBaixaCompte>();

            await _unitOfWork.WriteRepositoryFor<MotiuBaixaCompte>().AddAsync(motiuBaixaCompte);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(motiuBaixaCompte.Id, "Canal de cobrament creat correctament!");
        }
    }
}
