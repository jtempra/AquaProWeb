using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Queries
{
    public class GetTipusIncidenciaTecnicaByTextQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusIncidenciaTecnicaByTextQueryHandler : IRequestHandler<GetTipusIncidenciaTecnicaByTextQuery, ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaTecnicaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>> Handle(GetTipusIncidenciaTecnicaByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaTecnicaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusIncidenciaTecnicaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>().Success(tipusIncidenciaTecnicaDb.Adapt<List<ReadTipusIncidenciaTecnicaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>().Failure("No s'han trobat TipusIncidenciaTecnica!");
        }
    }
}
