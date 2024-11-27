using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.CanalsCobrament.Queries
{
    public class GetCanalsCobramentQuery : IRequest<ResponseWrapper<List<ReadCanalCobramentDTO>>>
    {
    }

    public class GetCanalsCobramentQueryHandler : IRequestHandler<GetCanalsCobramentQuery, ResponseWrapper<List<ReadCanalCobramentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCanalsCobramentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCanalCobramentDTO>>> Handle(GetCanalsCobramentQuery request, CancellationToken cancellationToken)
        {
            var canalsCobramentDb = await _unitOfWork.ReadRepositoryFor<CanalCobrament>().GetAllAsync();

            if (canalsCobramentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCanalCobramentDTO>>().Success(canalsCobramentDb.Adapt<List<ReadCanalCobramentDTO>>());
            }

            return new ResponseWrapper<List<ReadCanalCobramentDTO>>().Failure("No hi han canals de cobrament!");
        }
    }
}
