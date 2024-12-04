using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Queries
{
    public class GetTipusIncidenciaClientQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>>
    {
    }

    public class GetTipusIncidenciaClientQueryHandler : IRequestHandler<GetTipusIncidenciaClientQuery, ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>> Handle(GetTipusIncidenciaClientQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaClientDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusIncidenciaClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>().Success(tipusIncidenciaClientDb.Adapt<List<ReadTipusIncidenciaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>().Failure("No hi han TipusIncidenciaClient!");
        }
    }
}
