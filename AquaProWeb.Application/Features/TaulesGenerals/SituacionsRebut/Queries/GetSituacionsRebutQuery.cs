using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Queries
{
    public class GetSituacionsRebutQuery : IRequest<ResponseWrapper<List<ReadSituacioRebutDTO>>>
    {
    }

    public class GetSituacionsRebutQueryHandler : IRequestHandler<GetSituacionsRebutQuery, ResponseWrapper<List<ReadSituacioRebutDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacionsRebutQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSituacioRebutDTO>>> Handle(GetSituacionsRebutQuery request, CancellationToken cancellationToken)
        {
            var situacioRebutDb = await _unitOfWork.ReadRepositoryFor<SituacioRebut>().GetAllAsync();

            if (situacioRebutDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSituacioRebutDTO>>().Success(situacioRebutDb.Adapt<List<ReadSituacioRebutDTO>>());
            }

            return new ResponseWrapper<List<ReadSituacioRebutDTO>>().Failure("No hi han SituacionsRebut!");
        }
    }
}
