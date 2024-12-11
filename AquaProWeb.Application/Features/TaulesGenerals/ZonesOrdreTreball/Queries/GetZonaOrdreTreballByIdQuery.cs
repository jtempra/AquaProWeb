using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Queries
{
    public class GetZonaOrdreTreballByIdQuery : IRequest<ResponseWrapper<ReadZonaOrdreTreballDTO>>
    {
        public int Id { get; set; }
    }

    public class GetZonaOrdreTreballByIdQueryHandler : IRequestHandler<GetZonaOrdreTreballByIdQuery, ResponseWrapper<ReadZonaOrdreTreballDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonaOrdreTreballByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadZonaOrdreTreballDTO>> Handle(GetZonaOrdreTreballByIdQuery request, CancellationToken cancellationToken)
        {
            var zonaOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<ZonaOrdreTreball>().GetByIdAsync(request.Id);

            if (zonaOrdreTreballDb is not null)
            {
                return new ResponseWrapper<ReadZonaOrdreTreballDTO>().Success(zonaOrdreTreballDb.Adapt<ReadZonaOrdreTreballDTO>());
            }

            return new ResponseWrapper<ReadZonaOrdreTreballDTO>().Failure("La zona del OrdreTreball no existeix!");
        }
    }
}
