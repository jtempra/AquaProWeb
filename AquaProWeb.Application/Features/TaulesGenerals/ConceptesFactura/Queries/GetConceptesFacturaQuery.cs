using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesFactura.Queries
{
    public class GetConceptesFacturaQuery : IRequest<ResponseWrapper<List<ReadConcepteFacturaDTO>>>
    {
    }

    public class GetConceptesFacturaQueryHandler : IRequestHandler<GetConceptesFacturaQuery, ResponseWrapper<List<ReadConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConceptesFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadConcepteFacturaDTO>>> Handle(GetConceptesFacturaQuery request, CancellationToken cancellationToken)
        {
            var concepteFacturaDb = await _unitOfWork.ReadRepositoryFor<ConcepteFactura>().GetAllAsync();

            if (concepteFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadConcepteFacturaDTO>>().Success(concepteFacturaDb.Adapt<List<ReadConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadConcepteFacturaDTO>>().Failure("No hi han ConcepteFactura!");
        }
    }
}
