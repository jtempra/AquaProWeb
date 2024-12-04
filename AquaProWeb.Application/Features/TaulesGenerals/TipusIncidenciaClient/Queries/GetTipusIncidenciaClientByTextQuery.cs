using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Queries
{
    public class GetTipusIncidenciaClientByTextQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusIncidenciaClientByTextQueryHandler : IRequestHandler<GetTipusIncidenciaClientByTextQuery, ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaClientByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>> Handle(GetTipusIncidenciaClientByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaClientDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusIncidenciaClientDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>().Success(tipusIncidenciaClientDb.Adapt<List<ReadTipusIncidenciaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaClientDTO>>().Failure("No s'han trobat TipusIncidenciaClient!");
        }
    }
}
