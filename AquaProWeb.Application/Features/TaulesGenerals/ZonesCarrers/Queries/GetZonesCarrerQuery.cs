using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Queries
{
    public class GetZonesCarrerQuery : IRequest<ResponseWrapper<List<ReadZonaCarrerDTO>>>
    {
    }

    public class GetZonesCarrerQueryHandler : IRequestHandler<GetZonesCarrerQuery, ResponseWrapper<List<ReadZonaCarrerDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesCarrerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaCarrerDTO>>> Handle(GetZonesCarrerQuery request, CancellationToken cancellationToken)
        {
            var zonaCarrernsDb = await _unitOfWork.ReadRepositoryFor<ZonaCarrers>().GetAllAsync();

            if (zonaCarrernsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaCarrerDTO>>().Success(zonaCarrernsDb.Adapt<List<ReadZonaCarrerDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaCarrerDTO>>().Failure("No hi han zones de carrers!");
        }
    }
}
