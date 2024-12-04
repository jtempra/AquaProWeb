using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Queries
{
    public class GetTipusClientQuery : IRequest<ResponseWrapper<List<ReadTipusClientDTO>>>
    {
    }

    public class GetTipusClientQueryHandler : IRequestHandler<GetTipusClientQuery, ResponseWrapper<List<ReadTipusClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusClientDTO>>> Handle(GetTipusClientQuery request, CancellationToken cancellationToken)
        {
            var tipusClientDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusClientDTO>>().Success(tipusClientDb.Adapt<List<ReadTipusClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusClientDTO>>().Failure("No hi han TipusClient!");
        }
    }
}
