using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Queries
{
    public class GetTipusIncidenciaTecnicaQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>>
    {
    }

    public class GetTipusIncidenciaTecnicaQueryHandler : IRequestHandler<GetTipusIncidenciaTecnicaQuery, ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaTecnicaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>> Handle(GetTipusIncidenciaTecnicaQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaTecnicaDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusIncidenciaTecnicaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>().Success(tipusIncidenciaTecnicaDb.Adapt<List<ReadTipusIncidenciaTecnicaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaTecnicaDTO>>().Failure("No hi han TipusIncidenciaTecnica!");
        }
    }
}
