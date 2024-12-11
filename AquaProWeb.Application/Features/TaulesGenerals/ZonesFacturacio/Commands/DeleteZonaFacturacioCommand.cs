using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Commands
{
    public class DeleteZonaFacturacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteZonaFacturacioCommandHandler : IRequestHandler<DeleteZonaFacturacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteZonaFacturacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteZonaFacturacioCommand Request, CancellationToken cancellationToken)
        {
            var zonaFacturacioDb = await _unitOfWork.ReadRepositoryFor<ZonaFacturacio>().GetByIdAsync(Request.Id);

            if (zonaFacturacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ZonaFacturacio>().DeleteAsync(zonaFacturacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(zonaFacturacioDb.Id, "Zona Facturacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Zona Facturacio no trobada!");
        }
    }
}
