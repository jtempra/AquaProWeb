using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesConcepteFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesConcepteFactura.Queries
{
    public class GetFamiliesConcepteFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetEmpresesByTextQueryHandler : IRequestHandler<GetFamiliesConcepteFacturaByTextQuery, ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmpresesByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>> Handle(GetFamiliesConcepteFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var empresaDb = await _unitOfWork.ReadRepositoryFor<FamiliaConcepteFactura>().GetByTextAsync(request.Text);

            if (empresaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>().Success(empresaDb.Adapt<List<ReadFamiliaConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadFamiliaConcepteFacturaDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
