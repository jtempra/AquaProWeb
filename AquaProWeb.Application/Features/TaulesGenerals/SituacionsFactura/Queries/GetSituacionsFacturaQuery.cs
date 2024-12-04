using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Queries
{
    public class GetSituacionsFacturaQuery : IRequest<ResponseWrapper<List<ReadSituacioFacturaDTO>>>
    {
    }

    public class GetSituacionsFacturaQueryHandler : IRequestHandler<GetSituacionsFacturaQuery, ResponseWrapper<List<ReadSituacioFacturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacionsFacturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSituacioFacturaDTO>>> Handle(GetSituacionsFacturaQuery request, CancellationToken cancellationToken)
        {
            var situacioFacturaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (situacioFacturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSituacioFacturaDTO>>().Success(situacioFacturaDb.Adapt<List<ReadSituacioFacturaDTO>>());
            }

            return new ResponseWrapper<List<ReadSituacioFacturaDTO>>().Failure("No hi han SituacionsFactura!");
        }
    }
}
