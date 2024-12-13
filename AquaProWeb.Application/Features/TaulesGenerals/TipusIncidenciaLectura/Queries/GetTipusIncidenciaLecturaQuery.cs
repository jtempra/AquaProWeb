using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Queries
{
    public class GetTipusIncidenciaLecturaQuery : IRequest<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>>
    {
    }

    public class GetTipusIncidenciaLecturaQueryHandler : IRequestHandler<GetTipusIncidenciaLecturaQuery, ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaLecturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>> Handle(GetTipusIncidenciaLecturaQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaLecturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().GetAllAsync();

            if (tipusIncidenciaLecturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>().Success(tipusIncidenciaLecturaDb.Adapt<List<ReadTipusIncidenciaLecturaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusIncidenciaLecturaDTO>>().Failure("No hi han TipusIncidenciaLectura!");
        }
    }
}
