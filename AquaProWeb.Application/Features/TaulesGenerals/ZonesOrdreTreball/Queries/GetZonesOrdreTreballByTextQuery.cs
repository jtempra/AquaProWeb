using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesOrdreTreball.Queries
{
    public class GetZonesOrdreTreballByTextQuery : IRequest<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetZonesOrdreTreballByTextQueryHandler : IRequestHandler<GetZonesOrdreTreballByTextQuery, ResponseWrapper<List<ReadZonaOrdreTreballDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesOrdreTreballByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaOrdreTreballDTO>>> Handle(GetZonesOrdreTreballByTextQuery request, CancellationToken cancellationToken)
        {
            var ZonesOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (ZonesOrdreTreballDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaOrdreTreballDTO>>().Success(ZonesOrdreTreballDb.Adapt<List<ReadZonaOrdreTreballDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaOrdreTreballDTO>>().Failure("No s'han trobat ZonesOrdreTreball!");
        }
    }
}
