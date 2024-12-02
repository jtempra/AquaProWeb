using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Commands
{
    public class DeleteZonaCarrerCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteZonaCarrerCommandHandler : IRequestHandler<DeleteZonaCarrerCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteZonaCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteZonaCarrerCommand Request, CancellationToken cancellationToken)
        {
            var zonaCarrerDb = await _unitOfWork.ReadRepositoryFor<ZonaCarrers>().GetByIdAsync(Request.Id);

            if (zonaCarrerDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ZonaCarrers>().DeleteAsync(zonaCarrerDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaCarrerDb.Id, "Zona carrer esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Zona carrer no trobada!");
        }
    }
}
