using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Queries
{
    public class GetOperarisQuery : IRequest<ResponseWrapper<List<ReadOperariDTO>>>
    {
    }

    public class GetOperarisQueryHandler : IRequestHandler<GetOperarisQuery, ResponseWrapper<List<ReadOperariDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOperarisQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadOperariDTO>>> Handle(GetOperarisQuery request, CancellationToken cancellationToken)
        {
            var operariDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (operariDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadOperariDTO>>().Success(operariDb.Adapt<List<ReadOperariDTO>>());
            }

            return new ResponseWrapper<List<ReadOperariDTO>>().Failure("No hi han operaris!");
        }
    }
}
