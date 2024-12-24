using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Queries
{
    public class GetRutesLecturaQuery : IRequest<ResponseWrapper<List<ReadRutaLecturaDTO>>>
    {
    }

    public class GetRutesLecturaQueryHandler : IRequestHandler<GetRutesLecturaQuery, ResponseWrapper<List<ReadRutaLecturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRutesLecturaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> Handle(GetRutesLecturaQuery request, CancellationToken cancellationToken)
        {
            var rutesLecturaDb = await _unitOfWork.ReadRepositoryFor<RutaLectura>().GetAllAsync();

            if (rutesLecturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadRutaLecturaDTO>>().Success(rutesLecturaDb.Adapt<List<ReadRutaLecturaDTO>>());
            }

            return new ResponseWrapper<List<ReadRutaLecturaDTO>>().Failure("No hi han poblacions!");
        }
    }
}
