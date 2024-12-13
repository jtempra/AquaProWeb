using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusVies.Queries
{
    public class GetTipusViaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusViaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusViaByTextQueryHandler : IRequestHandler<GetTipusViaByTextQuery, ResponseWrapper<List<ReadTipusViaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusViaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusViaDTO>>> Handle(GetTipusViaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusViaDb = await _unitOfWork.ReadRepositoryFor<TipusVia>().GetByTextAsync(request.Text);

            if (tipusViaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusViaDTO>>().Success(tipusViaDb.Adapt<List<ReadTipusViaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusViaDTO>>().Failure("No s'han trobat TipusVia!");
        }
    }
}
