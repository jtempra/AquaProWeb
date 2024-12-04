using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Queries
{
    public class GetTipusComptadorByTextQuery : IRequest<ResponseWrapper<List<ReadTipusComptadorDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusComptadorByTextQueryHandler : IRequestHandler<GetTipusComptadorByTextQuery, ResponseWrapper<List<ReadTipusComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusComptadorByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusComptadorDTO>>> Handle(GetTipusComptadorByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusComptadorDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusComptadorDTO>>().Success(tipusComptadorDb.Adapt<List<ReadTipusComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusComptadorDTO>>().Failure("No s'han trobat TipusComptador!");
        }
    }
}
