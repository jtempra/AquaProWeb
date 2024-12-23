using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Commands
{
    public class CreateMotiuBaixaContacteCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveMotiuBaixaContacteDTO CreateMotiuBaixaContacte { get; set; }
    }

    public class CreateMotiuBaixaContacteCommandHandler : IRequestHandler<CreateMotiuBaixaContacteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMotiuBaixaContacteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateMotiuBaixaContacteCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var motiuBaixaContacte = request.CreateMotiuBaixaContacte.Adapt<MotiuBaixaContacte>();

            await _unitOfWork.WriteRepositoryFor<MotiuBaixaContacte>().AddAsync(motiuBaixaContacte);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(motiuBaixaContacte.Id, "Canal de cobrament creat correctament!");
        }
    }
}
