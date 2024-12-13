using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Queries
{
    public class GetTipusBaixaClientByTextQuery : IRequest<ResponseWrapper<List<ReadTipusBaixaClientDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusBaixaClientByTextQueryHandler : IRequestHandler<GetTipusBaixaClientByTextQuery, ResponseWrapper<List<ReadTipusBaixaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusBaixaClientByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusBaixaClientDTO>>> Handle(GetTipusBaixaClientByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusBaixaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusBaixaClient>().GetByTextAsync(request.Text);

            if (tipusBaixaClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusBaixaClientDTO>>().Success(tipusBaixaClientDb.Adapt<List<ReadTipusBaixaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusBaixaClientDTO>>().Failure("No s'han trobat TipusBaixaClient!");
        }
    }
}
