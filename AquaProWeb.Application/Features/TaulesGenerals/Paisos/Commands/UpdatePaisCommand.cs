using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Commands
{
    public class UpdatePaisCommand : IRequest<ResponseWrapper<int>>
    {
        public SavePaisDTO UpdatePais { get; set; }
    }

    public class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePaisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var paisDb = await _unitOfWork.ReadRepositoryFor<Pais>().GetByIdAsync(request.UpdatePais.Id);

            if (paisDb is not null)
            {
                request.UpdatePais.Adapt(paisDb);

                await _unitOfWork.WriteRepositoryFor<Pais>().UpdateAsync(paisDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(paisDb.Id, "Pais actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Pais no existeix!");

        }
    }
}
