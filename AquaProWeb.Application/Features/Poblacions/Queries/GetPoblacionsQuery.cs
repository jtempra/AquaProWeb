using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Poblacions.Queries
{
    public class GetPoblacionsQuery : IRequest<ResponseWrapper<List<ReadPoblacioDTO>>>
    {
    }

    public class GetPoblacionsQueryHandler : IRequestHandler<GetPoblacionsQuery, ResponseWrapper<List<ReadPoblacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPoblacionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadPoblacioDTO>>> Handle(GetPoblacionsQuery request, CancellationToken cancellationToken)
        {
            var poblacionsDb = await _unitOfWork.ReadRepositoryFor<Poblacio>().GetAllAsync();

            if (poblacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadPoblacioDTO>>().Success(poblacionsDb.Adapt<List<ReadPoblacioDTO>>());
            }

            return new ResponseWrapper<List<ReadPoblacioDTO>>().Failure("No hi han poblacions!");
        }
    }
}
