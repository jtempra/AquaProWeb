using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ZonesFacturacio.Queries
{
    public class GetZonesFacturacioByTextQuery : IRequest<ResponseWrapper<List<ReadZonaFacturacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetZonesFacturacioByTextQueryHandler : IRequestHandler<GetZonesFacturacioByTextQuery, ResponseWrapper<List<ReadZonaFacturacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetZonesFacturacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadZonaFacturacioDTO>>> Handle(GetZonesFacturacioByTextQuery request, CancellationToken cancellationToken)
        {
            var ZonesFacturacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (ZonesFacturacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadZonaFacturacioDTO>>().Success(ZonesFacturacioDb.Adapt<List<ReadZonaFacturacioDTO>>());
            }

            return new ResponseWrapper<List<ReadZonaFacturacioDTO>>().Failure("No s'han trobat ZonesFacturacio!");
        }
    }
}
