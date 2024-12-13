using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Queries
{
    public class GetTipusOrdreTreballByTextQuery : IRequest<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusOrdreTreballByTextQueryHandler : IRequestHandler<GetTipusOrdreTreballByTextQuery, ResponseWrapper<List<ReadTipusOrdreTreballDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusOrdreTreballByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusOrdreTreballDTO>>> Handle(GetTipusOrdreTreballByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusOrdreTreball>().GetByTextAsync(request.Text);

            if (tipusOrdreTreballDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusOrdreTreballDTO>>().Success(tipusOrdreTreballDb.Adapt<List<ReadTipusOrdreTreballDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusOrdreTreballDTO>>().Failure("No s'han trobat TipusOrdreTreball!");
        }
    }
}
