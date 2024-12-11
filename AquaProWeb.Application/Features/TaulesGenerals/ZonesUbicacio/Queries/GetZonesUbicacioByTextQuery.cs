using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesUbicacio.Queries
{
    public class GetZonesUbicacioByTextQuery : IRequest<ResponseWrapper<List<ReadZonaUbicacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetZonesUbicacioByTextQueryHandler : IRequestHandler<GetZonesUbicacioByTextQuery, ResponseWrapper<List<ReadZonaUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesUbicacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaUbicacioDTO>>> Handle(GetZonesUbicacioByTextQuery request, CancellationToken cancellationToken)
        {
            var ZonesUbicacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (ZonesUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaUbicacioDTO>>().Success(ZonesUbicacioDb.Adapt<List<ReadZonaUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaUbicacioDTO>>().Failure("No s'han trobat ZonesUbicacio!");
        }
    }
}
