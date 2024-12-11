using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesCarrers.Queries
{
    public class GetZonesCarrerByTextQuery : IRequest<ResponseWrapper<List<ReadZonaCarrerDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetZonesCarrerByTextQueryHandler : IRequestHandler<GetZonesCarrerByTextQuery, ResponseWrapper<List<ReadZonaCarrerDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesCarrerByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaCarrerDTO>>> Handle(GetZonesCarrerByTextQuery request, CancellationToken cancellationToken)
        {
            var ZonesCarrerDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (ZonesCarrerDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaCarrerDTO>>().Success(ZonesCarrerDb.Adapt<List<ReadZonaCarrerDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaCarrerDTO>>().Failure("No s'han trobat ZonesCarrer!");
        }
    }
}
