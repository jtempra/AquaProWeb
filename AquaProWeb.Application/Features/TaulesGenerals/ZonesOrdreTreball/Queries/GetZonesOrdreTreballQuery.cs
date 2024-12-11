using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Queries
{
    public class GetZonesOrdreTreballQuery : IRequest<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>>
    {
    }

    public class GetZonesOrdreTreballQueryHandler : IRequestHandler<GetZonesOrdreTreballQuery, ResponseWrapper<List<ReadZonaOrdreTreballDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesOrdreTreballQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>> Handle(GetZonesOrdreTreballQuery request, CancellationToken cancellationToken)
        {
            var zonaOrdreTreballnsDb = await _unitOfWork.ReadRepositoryFor<ZonaOrdreTreball>().GetAllAsync();

            if (zonaOrdreTreballnsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaOrdreTreballDTO>>().Success(zonaOrdreTreballnsDb.Adapt<List<ReadZonaOrdreTreballDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaOrdreTreballDTO>>().Failure("No hi han zones de OrdreTreballs!");
        }
    }
}
