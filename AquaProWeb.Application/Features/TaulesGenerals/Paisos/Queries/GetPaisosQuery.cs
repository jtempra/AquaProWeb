using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries
{
    public class GetPaisosQuery : IRequest<ResponseWrapper<List<ReadPaisDTO>>>
    {
    }

    public class GetPaisosQueryHandler : IRequestHandler<GetPaisosQuery, ResponseWrapper<List<ReadPaisDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaisosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadPaisDTO>>> Handle(GetPaisosQuery request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<Pais>().GetAllAsync();

            if (paisDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadPaisDTO>>().Success(paisDb.Adapt<List<ReadPaisDTO>>());
            }

            return new ResponseWrapper<List<ReadPaisDTO>>().Failure("No hi han Paisos!");
        }
    }
}
