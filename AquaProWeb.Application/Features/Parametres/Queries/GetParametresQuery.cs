using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Queries
{
    public class GetParametresQuery : IRequest<ResponseWrapper<List<ReadParametreDTO>>>
    {
    }

    public class GetParametresQueryHandler : IRequestHandler<GetParametresQuery, ResponseWrapper<List<ReadParametreDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetParametresQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadParametreDTO>>> Handle(GetParametresQuery request, CancellationToken cancellationToken)
        {
            var ParametresDb = await _unitOfWork.ReadRepositoryFor<Parametre>().GetAllAsync();

            if (ParametresDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadParametreDTO>>().Success(ParametresDb.Adapt<List<ReadParametreDTO>>());
            }

            return new ResponseWrapper<List<ReadParametreDTO>>().Failure("No hi han Parametres!");
        }
    }
}
