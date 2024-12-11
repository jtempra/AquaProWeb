using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Queries
{
    public class GetTipusQueixaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusQueixaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusQueixaByTextQueryHandler : IRequestHandler<GetTipusQueixaByTextQuery, ResponseWrapper<List<ReadTipusQueixaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusQueixaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusQueixaDTO>>> Handle(GetTipusQueixaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusQueixaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusQueixaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusQueixaDTO>>().Success(tipusQueixaDb.Adapt<List<ReadTipusQueixaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusQueixaDTO>>().Failure("No s'han trobat TipusQueixa!");
        }
    }
}
