using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Queries
{
    public class GetTipusFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusFacturaByTextQueryHandler : IRequestHandler<GetTipusFacturaByTextQuery, ResponseWrapper<List<ReadTipusFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusFacturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusFacturaDTO>>> Handle(GetTipusFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusFacturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusFacturaDTO>>().Success(tipusFacturaDb.Adapt<List<ReadTipusFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusFacturaDTO>>().Failure("No s'han trobat TipusFactura!");
        }
    }
}
