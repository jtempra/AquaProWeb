using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Commands
{
    public class UpdateMarcaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateMarcaComptadorDTO UpdateMarcaComptador { get; set; }
    }

    public class UpdateMarcaComptadorCommandHandler : IRequestHandler<UpdateMarcaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMarcaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateMarcaComptadorCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var marcaComptadorDb = await _unitOfWork.ReadRepositoryFor<MarcaComptador>().GetByIdAsync(request.UpdateMarcaComptador.Id);

            if (marcaComptadorDb is not null)
            {
                request.UpdateMarcaComptador.Adapt(marcaComptadorDb);

                await _unitOfWork.WriteRepositoryFor<MarcaComptador>().UpdateAsync(marcaComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(marcaComptadorDb.Id, "Canal de cobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El canal de ccobrament no existeix!");

        }
    }
}
