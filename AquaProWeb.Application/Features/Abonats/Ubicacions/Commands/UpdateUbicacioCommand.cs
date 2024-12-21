using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Commands
{
    public class UpdateUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateUbicacioDTO UpdateUbicacio { get; set; }
    }

    public class UpdateUbicacioCommandHandler : IRequestHandler<UpdateUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateUbicacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var UbicacioDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByIdAsync(request.UpdateUbicacio.Id);

            if (UbicacioDb is not null)
            {
                request.UpdateUbicacio.Adapt(UbicacioDb);

                await _unitOfWork.WriteRepositoryFor<Ubicacio>().UpdateAsync(UbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(UbicacioDb.Id, "Ubicacio actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Ubicacio no existeix!");

        }
    }
}
