using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Queries
{
    public class GetZonaCarrerByIdQuery : IRequest<ResponseWrapper<ReadZonaCarrerDTO>>
    {
        public int Id { get; set; }
    }

    public class GetZonaCarrerByIdQueryHandler : IRequestHandler<GetZonaCarrerByIdQuery, ResponseWrapper<ReadZonaCarrerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonaCarrerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadZonaCarrerDTO>> Handle(GetZonaCarrerByIdQuery request, CancellationToken cancellationToken)
        {
            var zonaCarrerDb = await _unitOfWork.ReadRepositoryFor<ZonaCarrers>().GetByIdAsync(request.Id);

            if (zonaCarrerDb is not null)
            {
                return new ResponseWrapper<ReadZonaCarrerDTO>().Success(zonaCarrerDb.Adapt<ReadZonaCarrerDTO>());
            }

            return new ResponseWrapper<ReadZonaCarrerDTO>().Failure("La zona del carrer no existeix!");
        }
    }
}
