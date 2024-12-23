using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Commands
{
    public class UpdateMotiuBaixaContacteCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveMotiuBaixaContacteDTO UpdateMotiuBaixaContacte { get; set; }
    }

    public class UpdateMotiuBaixaContacteCommandHandler : IRequestHandler<UpdateMotiuBaixaContacteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotiuBaixaContacteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateMotiuBaixaContacteCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var motiuBaixaContacteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaContacte>().GetByIdAsync(request.UpdateMotiuBaixaContacte.Id);

            if (motiuBaixaContacteDb is not null)
            {
                request.UpdateMotiuBaixaContacte.Adapt(motiuBaixaContacteDb);

                await _unitOfWork.WriteRepositoryFor<MotiuBaixaContacte>().UpdateAsync(motiuBaixaContacteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(motiuBaixaContacteDb.Id, "Canal de cobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El motiu de baixa de Contacte no existeix!");

        }
    }
}
