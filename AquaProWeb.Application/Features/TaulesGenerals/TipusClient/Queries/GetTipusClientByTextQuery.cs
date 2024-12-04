using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Queries
{
    public class GetTipusClientByTextQuery : IRequest<ResponseWrapper<List<ReadTipusClientDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusClientByTextQueryHandler : IRequestHandler<GetTipusClientByTextQuery, ResponseWrapper<List<ReadTipusClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusClientByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusClientDTO>>> Handle(GetTipusClientByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusClientDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusClientDTO>>().Success(tipusClientDb.Adapt<List<ReadTipusClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusClientDTO>>().Failure("No s'han trobat TipusClient!");
        }
    }
}
