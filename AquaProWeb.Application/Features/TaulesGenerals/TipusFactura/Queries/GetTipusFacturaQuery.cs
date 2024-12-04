using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Queries
{
    public class GetTipusFacturaQuery : IRequest<ResponseWrapper<List<ReadTipusFacturaDTO>>>
    {
    }

    public class GetTipusFacturaQueryHandler : IRequestHandler<GetTipusFacturaQuery, ResponseWrapper<List<ReadTipusFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusFacturaDTO>>> Handle(GetTipusFacturaQuery request, CancellationToken cancellationToken)
        {
            var tipusFacturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusFacturaDTO>>().Success(tipusFacturaDb.Adapt<List<ReadTipusFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusFacturaDTO>>().Failure("No hi han TipusFactura!");
        }
    }
}
