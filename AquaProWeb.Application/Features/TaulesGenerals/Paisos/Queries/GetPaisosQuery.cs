using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries
{
    public class GetPaisosQuery : IRequest<ResponseWrapper<List<ReadOperariDTO>>>
    {
    }

    public class GetPaisosQueryHandler : IRequestHandler<GetPaisosQuery, ResponseWrapper<List<ReadOperariDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaisosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadOperariDTO>>> Handle(GetPaisosQuery request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (paisDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadOperariDTO>>().Success(paisDb.Adapt<List<ReadOperariDTO>>());
            }

            return new ResponseWrapper<List<ReadOperariDTO>>().Failure("No hi han Paisos!");
        }
    }
}
