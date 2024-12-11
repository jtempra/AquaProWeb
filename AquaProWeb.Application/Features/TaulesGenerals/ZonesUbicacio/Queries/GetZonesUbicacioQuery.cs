using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Queries
{
    public class GetZonesUbicacioQuery : IRequest<ResponseWrapper<List<ReadZonaUbicacioDTO>>>
    {
    }

    public class GetZonesUbicacioQueryHandler : IRequestHandler<GetZonesUbicacioQuery, ResponseWrapper<List<ReadZonaUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesUbicacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaUbicacioDTO>>> Handle(GetZonesUbicacioQuery request, CancellationToken cancellationToken)
        {
            var ZonaUbicacioDb = await _unitOfWork.ReadRepositoryFor<ZonaUbicacio>().GetAllAsync();

            if (ZonaUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaUbicacioDTO>>().Success(ZonaUbicacioDb.Adapt<List<ReadZonaUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaUbicacioDTO>>().Failure("No hi han zones de Ubicacios!");
        }
    }
}
