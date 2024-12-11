using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Commands
{
    public class DeleteZonaOrdreTreballCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteZonaOrdreTreballCommandHandler : IRequestHandler<DeleteZonaOrdreTreballCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteZonaOrdreTreballCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteZonaOrdreTreballCommand Request, CancellationToken cancellationToken)
        {
            var zonaOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<ZonaOrdreTreball>().GetByIdAsync(Request.Id);

            if (zonaOrdreTreballDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ZonaOrdreTreball>().DeleteAsync(zonaOrdreTreballDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaOrdreTreballDb.Id, "Zona OrdreTreball esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Zona OrdreTreball no trobada!");
        }
    }
}
