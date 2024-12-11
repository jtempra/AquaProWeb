using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Queries
{
    public class GetZonesFacturacioQuery : IRequest<ResponseWrapper<List<ReadZonaFacturacioDTO>>>
    {
    }

    public class GetZonesFacturacioQueryHandler : IRequestHandler<GetZonesFacturacioQuery, ResponseWrapper<List<ReadZonaFacturacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesFacturacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaFacturacioDTO>>> Handle(GetZonesFacturacioQuery request, CancellationToken cancellationToken)
        {
            var zonaFacturacionsDb = await _unitOfWork.ReadRepositoryFor<ZonaFacturacio>().GetAllAsync();

            if (zonaFacturacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaFacturacioDTO>>().Success(zonaFacturacionsDb.Adapt<List<ReadZonaFacturacioDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaFacturacioDTO>>().Failure("No hi han zones de Facturacios!");
        }
    }
}
