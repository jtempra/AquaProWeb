using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Queries
{
    public class GetTipusCampanyaQuery : IRequest<ResponseWrapper<List<ReadTipusCampanyaDTO>>>
    {
    }

    public class GetTipusCampanyaQueryHandler : IRequestHandler<GetTipusCampanyaQuery, ResponseWrapper<List<ReadTipusCampanyaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusCampanyaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusCampanyaDTO>>> Handle(GetTipusCampanyaQuery request, CancellationToken cancellationToken)
        {
            var tipusCampanyaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusCampanya>().GetAllAsync();

            if (tipusCampanyaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusCampanyaDTO>>().Success(tipusCampanyaDb.Adapt<List<ReadTipusCampanyaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusCampanyaDTO>>().Failure("No hi han TipusCampanya!");
        }
    }
}
