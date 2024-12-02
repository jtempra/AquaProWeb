using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusVies.Queries
{
    public class GetTipusViaQuery : IRequest<ResponseWrapper<List<ReadTipusViaDTO>>>
    {
    }

    public class GetTipusViaQueryHandler : IRequestHandler<GetTipusViaQuery, ResponseWrapper<List<ReadTipusViaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusViaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusViaDTO>>> Handle(GetTipusViaQuery request, CancellationToken cancellationToken)
        {
            var tipusViaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusVia>().GetAllAsync();

            if (tipusViaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusViaDTO>>().Success(tipusViaDb.Adapt<List<ReadTipusViaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusViaDTO>>().Failure("No hi han tipus de via!");
        }
    }
}
