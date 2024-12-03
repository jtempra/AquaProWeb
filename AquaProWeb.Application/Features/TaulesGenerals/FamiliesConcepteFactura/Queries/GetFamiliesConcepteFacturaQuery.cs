using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesConcepteFactura.Queries
{
    public class GetFamiliesConcepteFacturaQuery : IRequest<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>>
    {
    }

    public class GetFamiliesConcepteFacturaQueryHandler : IRequestHandler<GetFamiliesConcepteFacturaQuery, ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliesConcepteFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> Handle(GetFamiliesConcepteFacturaQuery request, CancellationToken cancellationToken)
        {
            var familiaConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<FamiliaConcepteFactura>().GetAllAsync();

            if (familiaConcepteFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>().Success(familiaConcepteFacturaDb.Adapt<List<ReadFamiliaConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>().Failure("No hi han Empresas!");
        }
    }
}
