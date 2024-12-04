using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Queries
{
    public class GetTipusConcepteFacturaQuery : IRequest<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>>
    {
    }

    public class GetTipusConcepteFacturaQueryHandler : IRequestHandler<GetTipusConcepteFacturaQuery, ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusConcepteFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>> Handle(GetTipusConcepteFacturaQuery request, CancellationToken cancellationToken)
        {
            var tipusConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusConcepteFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>().Success(tipusConcepteFacturaDb.Adapt<List<ReadTipusConcepteFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusConcepteFacturaDTO>>().Failure("No hi han TipusConcepteFactura!");
        }
    }
}
