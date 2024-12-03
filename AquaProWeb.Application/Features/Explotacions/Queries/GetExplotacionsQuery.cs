using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Explotacions.Queries
{
    public class GetParametreQuery : IRequest<ResponseWrapper<List<ReadExplotacioDTO>>>
    {
    }

    public class GetExplotacionsQueryHandler : IRequestHandler<GetParametreQuery, ResponseWrapper<List<ReadExplotacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExplotacionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadExplotacioDTO>>> Handle(GetParametreQuery request, CancellationToken cancellationToken)
        {
            var explotacionsDb = await _unitOfWork.ReadRepositoryFor<Explotacio>().GetAllAsync();

            if (explotacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadExplotacioDTO>>().Success(explotacionsDb.Adapt<List<ReadExplotacioDTO>>());
            }

            return new ResponseWrapper<List<ReadExplotacioDTO>>().Failure("No hi han explotacions!");
        }
    }
}
