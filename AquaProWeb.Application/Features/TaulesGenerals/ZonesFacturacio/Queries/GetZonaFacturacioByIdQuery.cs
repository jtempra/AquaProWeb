using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Queries
{
    public class GetZonaFacturacioByIdQuery : IRequest<ResponseWrapper<ReadZonaFacturacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetZonaFacturacioByIdQueryHandler : IRequestHandler<GetZonaFacturacioByIdQuery, ResponseWrapper<ReadZonaFacturacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonaFacturacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadZonaFacturacioDTO>> Handle(GetZonaFacturacioByIdQuery request, CancellationToken cancellationToken)
        {
            var zonaFacturacioDb = await _unitOfWork.ReadRepositoryFor<ZonaFacturacio>().GetByIdAsync(request.Id);

            if (zonaFacturacioDb is not null)
            {
                return new ResponseWrapper<ReadZonaFacturacioDTO>().Success(zonaFacturacioDb.Adapt<ReadZonaFacturacioDTO>());
            }

            return new ResponseWrapper<ReadZonaFacturacioDTO>().Failure("La zona del Facturacio no existeix!");
        }
    }
}
