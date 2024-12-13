using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Queries
{
    public class GetTipusConcepteFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusConcepteFacturaByTextQueryHandler : IRequestHandler<GetTipusConcepteFacturaByTextQuery, ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusConcepteFacturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>> Handle(GetTipusConcepteFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusConcepteFactura>().GetByTextAsync(request.Text);

            if (tipusConcepteFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>().Success(tipusConcepteFacturaDb.Adapt<List<ReadTipusConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>().Failure("No s'han trobat TipusConcepteFactura!");
        }
    }
}
