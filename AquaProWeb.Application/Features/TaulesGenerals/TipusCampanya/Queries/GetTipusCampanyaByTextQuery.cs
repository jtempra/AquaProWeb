using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Queries
{
    public class GetTipusCampanyaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusCampanyaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusCampanyaByTextQueryHandler : IRequestHandler<GetTipusCampanyaByTextQuery, ResponseWrapper<List<ReadTipusCampanyaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusCampanyaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusCampanyaDTO>>> Handle(GetTipusCampanyaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusCampanyaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusCampanyaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusCampanyaDTO>>().Success(tipusCampanyaDb.Adapt<List<ReadTipusCampanyaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusCampanyaDTO>>().Failure("No s'han trobat TipusCampanya!");
        }
    }
}
