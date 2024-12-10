using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Queries
{
    public class GetTipusOrdreTreballQuery : IRequest<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>>
    {
    }

    public class GetTipusOrdreTreballQueryHandler : IRequestHandler<GetTipusOrdreTreballQuery, ResponseWrapper<List<ReadTipusOrdreTreballDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusOrdreTreballQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>> Handle(GetTipusOrdreTreballQuery request, CancellationToken cancellationToken)
        {
            var tipusOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusOrdreTreballDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusOrdreTreballDTO>>().Success(tipusOrdreTreballDb.Adapt<List<ReadTipusOrdreTreballDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusOrdreTreballDTO>>().Failure("No hi han TipusOrdreTreball!");
        }
    }
}
