using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Queries
{
    public class GetTipusIncidenciaUbicacioByTextQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusIncidenciaUbicacioByTextQueryHandler : IRequestHandler<GetTipusIncidenciaUbicacioByTextQuery, ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaUbicacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>> Handle(GetTipusIncidenciaUbicacioByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaUbicacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (tipusIncidenciaUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>().Success(tipusIncidenciaUbicacioDb.Adapt<List<ReadTipusIncidenciaUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>().Failure("No s'han trobat TipusIncidenciaUbicacio!");
        }
    }
}
