using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Commands
{
    public class CreateMotiuBaixaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateMotiuBaixaComptadorDTO CreateMotiuBaixaComptador { get; set; }
    }

    public class CreateMotiuBaixaComptadorCommandHandler : IRequestHandler<CreateMotiuBaixaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotiuBaixaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateMotiuBaixaComptadorCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var motiuBaixaComptador = request.CreateMotiuBaixaComptador.Adapt<MotiuBaixaComptador>();

            await _unitOfWork.WriteRepositoryFor<MotiuBaixaComptador>().AddAsync(motiuBaixaComptador);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(motiuBaixaComptador.Id, "Canal de cobrament creat correctament!");
        }
    }
}
