using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Queries
{
    public class GetConceptesFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadConcepteFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetConceptesFacturaByTextQueryHandler : IRequestHandler<GetConceptesFacturaByTextQuery, ResponseWrapper<List<ReadConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConceptesFacturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> Handle(GetConceptesFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var concepteFacturasDb = await _unitOfWork.ReadRepositoryFor<ConcepteFactura>().GetByTextAsync(request.Text);

            if (concepteFacturasDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadConcepteFacturaDTO>>().Success(concepteFacturasDb.Adapt<List<ReadConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadConcepteFacturaDTO>>().Failure("No s'han trobat ConcepteFacturas!");
        }
    }
}
