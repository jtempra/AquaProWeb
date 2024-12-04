using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusBaixaClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Queries
{
    public class GetTipusBaixaClientQuery : IRequest<ResponseWrapper<List<ReadTipusBaixaClientDTO>>>
    {
    }

    public class GetTipusBaixaClientQueryHandler : IRequestHandler<GetTipusBaixaClientQuery, ResponseWrapper<List<ReadTipusBaixaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusBaixaClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusBaixaClientDTO>>> Handle(GetTipusBaixaClientQuery request, CancellationToken cancellationToken)
        {
            var tipusBaixaClientDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusBaixaClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusBaixaClientDTO>>().Success(tipusBaixaClientDb.Adapt<List<ReadTipusBaixaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusBaixaClientDTO>>().Failure("No hi han TipusBaixaClient!");
        }
    }
}
