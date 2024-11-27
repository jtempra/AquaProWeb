using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Carrers.Commands
{
    public class UpdateCarrerCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateCarrerDTO UpdateCarrer { get; set; }
    }

    public class UpdateCarrerCommandHandler : IRequestHandler<UpdateCarrerCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateCarrerCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var carrerDb = await _unitOfWork.ReadRepositoryFor<Carrer>().GetByIdAsync(request.UpdateCarrer.Id);

            if (carrerDb is not null)
            {
                request.UpdateCarrer.Adapt(carrerDb);

                await _unitOfWork.WriteRepositoryFor<Carrer>().UpdateAsync(carrerDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(carrerDb.Id, "Carrer actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El carrer no existeix!");

        }
    }
}
