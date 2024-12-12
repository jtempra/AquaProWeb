using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Queries
{
    public class GetSituacionsRebutByTextQuery : IRequest<ResponseWrapper<List<ReadSituacioRebutDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetSituacionsRebutByTextQueryHandler : IRequestHandler<GetSituacionsRebutByTextQuery, ResponseWrapper<List<ReadSituacioRebutDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacionsRebutByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadSituacioRebutDTO>>> Handle(GetSituacionsRebutByTextQuery request, CancellationToken cancellationToken)
        {
            var situacioRebutDb = await _unitOfWork.ReadRepositoryFor<SituacioRebut>().GetByTextAsync(request.Text);

            if (situacioRebutDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadSituacioRebutDTO>>().Success(situacioRebutDb.Adapt<List<ReadSituacioRebutDTO>>());
            }

            return new ResponseWrapper<List<ReadSituacioRebutDTO>>().Failure("No s'han trobat SituacionsRebut!");
        }
    }
}
