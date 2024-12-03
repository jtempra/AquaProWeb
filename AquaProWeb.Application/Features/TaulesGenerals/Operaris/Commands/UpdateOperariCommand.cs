using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Commands
{
    public class UpdateOperariCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateOperariDTO UpdateOperari { get; set; }
    }

    public class UpdateOperariCommandHandler : IRequestHandler<UpdateOperariCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOperariCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateOperariCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var operariDb = await _unitOfWork.ReadRepositoryFor<Operari>().GetByIdAsync(request.UpdateOperari.Id);

            if (operariDb is not null)
            {
                request.UpdateOperari.Adapt(operariDb);

                await _unitOfWork.WriteRepositoryFor<Operari>().UpdateAsync(operariDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(operariDb.Id, "Operari actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Operari no existeix!");

        }
    }
}
