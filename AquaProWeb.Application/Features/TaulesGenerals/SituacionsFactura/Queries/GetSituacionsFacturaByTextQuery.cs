using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Queries
{
    public class GetSituacionsFacturaByTextQuery : IRequest<ResponseWrapper<List<ReadSituacioFacturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetSituacionsFacturaByTextQueryHandler : IRequestHandler<GetSituacionsFacturaByTextQuery, ResponseWrapper<List<ReadSituacioFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacionsFacturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> Handle(GetSituacionsFacturaByTextQuery request, CancellationToken cancellationToken)
        {
            var situacioFacturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (situacioFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSituacioFacturaDTO>>().Success(situacioFacturaDb.Adapt<List<ReadSituacioFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadSituacioFacturaDTO>>().Failure("No s'han trobat SituacionsFactura!");
        }
    }
}
