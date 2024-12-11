using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Commands
{
    public class DeleteZonaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteZonaUbicacioCommandHandler : IRequestHandler<DeleteZonaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteZonaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteZonaUbicacioCommand Request, CancellationToken cancellationToken)
        {
            var zonaUbicacioDb = await _unitOfWork.ReadRepositoryFor<ZonaUbicacio>().GetByIdAsync(Request.Id);

            if (zonaUbicacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ZonaUbicacio>().DeleteAsync(zonaUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaUbicacioDb.Id, "Zona Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Zona Ubicacio no trobada!");
        }
    }
}
