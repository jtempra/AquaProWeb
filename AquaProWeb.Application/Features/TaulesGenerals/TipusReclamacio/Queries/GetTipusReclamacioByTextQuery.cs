using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Queries
{
    public class GetTipusReclamacioByTextQuery : IRequest<ResponseWrapper<List<ReadTipusReclamacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusReclamacioByTextQueryHandler : IRequestHandler<GetTipusReclamacioByTextQuery, ResponseWrapper<List<ReadTipusReclamacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusReclamacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusReclamacioDTO>>> Handle(GetTipusReclamacioByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusReclamacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusReclamacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusReclamacioDTO>>().Success(tipusReclamacioDb.Adapt<List<ReadTipusReclamacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusReclamacioDTO>>().Failure("No s'han trobat TipusReclamacio!");
        }
    }
}
