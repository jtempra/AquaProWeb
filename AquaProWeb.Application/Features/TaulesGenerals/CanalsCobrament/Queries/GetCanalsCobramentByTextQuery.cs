using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Queries
{
    public class GetCanalsCobramentByTextQuery : IRequest<ResponseWrapper<List<ReadCanalCobramentDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetCanalsCobramentByTextQueryHandler : IRequestHandler<GetCanalsCobramentByTextQuery, ResponseWrapper<List<ReadCanalCobramentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCanalsCobramentByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCanalCobramentDTO>>> Handle(GetCanalsCobramentByTextQuery request, CancellationToken cancellationToken)
        {
            var CanalsCobramentDb = await _unitOfWork.ReadRepositoryFor<CanalCobrament>().GetByTextAsync(request.Text);

            if (CanalsCobramentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCanalCobramentDTO>>().Success(CanalsCobramentDb.Adapt<List<ReadCanalCobramentDTO>>());
            }

            return new ResponseWrapper<List<ReadCanalCobramentDTO>>().Failure("No s'han trobat CanalsCobrament!");
        }
    }
}
