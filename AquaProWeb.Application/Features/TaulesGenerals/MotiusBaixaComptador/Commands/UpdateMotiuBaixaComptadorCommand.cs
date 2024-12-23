using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Commands
{
    public class UpdateMotiuBaixaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveMotiuBaixaComptadorDTO UpdateMotiuBaixaComptador { get; set; }
    }

    public class UpdateMotiuBaixaComptadorCommandHandler : IRequestHandler<UpdateMotiuBaixaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMotiuBaixaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateMotiuBaixaComptadorCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var motiuBaixaComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaComptador>().GetByIdAsync(request.UpdateMotiuBaixaComptador.Id);

            if (motiuBaixaComptadorDb is not null)
            {
                request.UpdateMotiuBaixaComptador.Adapt(motiuBaixaComptadorDb);

                await _unitOfWork.WriteRepositoryFor<MotiuBaixaComptador>().UpdateAsync(motiuBaixaComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(motiuBaixaComptadorDb.Id, "Canal de cobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El motiu de baixa de comptador no existeix!");

        }
    }
}
