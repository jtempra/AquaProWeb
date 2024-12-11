using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Queries
{
    public class GetZonaUbicacioByIdQuery : IRequest<ResponseWrapper<ReadZonaUbicacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetZonaUbicacioByIdQueryHandler : IRequestHandler<GetZonaUbicacioByIdQuery, ResponseWrapper<ReadZonaUbicacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonaUbicacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadZonaUbicacioDTO>> Handle(GetZonaUbicacioByIdQuery request, CancellationToken cancellationToken)
        {
            var zonaUbicacioDb = await _unitOfWork.ReadRepositoryFor<ZonaUbicacio>().GetByIdAsync(request.Id);

            if (zonaUbicacioDb is not null)
            {
                return new ResponseWrapper<ReadZonaUbicacioDTO>().Success(zonaUbicacioDb.Adapt<ReadZonaUbicacioDTO>());
            }

            return new ResponseWrapper<ReadZonaUbicacioDTO>().Failure("La zona del Ubicacio no existeix!");
        }
    }
}
