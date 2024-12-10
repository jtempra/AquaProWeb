using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Queries
{
    public class GetTipusIncidenciaUbicacioQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>>
    {
    }

    public class GetTipusIncidenciaUbicacioQueryHandler : IRequestHandler<GetTipusIncidenciaUbicacioQuery, ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaUbicacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>> Handle(GetTipusIncidenciaUbicacioQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaUbicacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusIncidenciaUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>().Success(tipusIncidenciaUbicacioDb.Adapt<List<ReadTipusIncidenciaUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaUbicacioDTO>>().Failure("No hi han TipusIncidenciaUbicacio!");
        }
    }
}
