using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Queries
{
    public class GetTipusIncidenciaContracteQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>>
    {
    }

    public class GetTipusIncidenciaContracteQueryHandler : IRequestHandler<GetTipusIncidenciaContracteQuery, ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaContracteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>> Handle(GetTipusIncidenciaContracteQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().GetAllAsync();

            if (tipusIncidenciaContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>().Success(tipusIncidenciaContracteDb.Adapt<List<ReadTipusIncidenciaContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaContracteDTO>>().Failure("No hi han TipusIncidenciaContracte!");
        }
    }
}
