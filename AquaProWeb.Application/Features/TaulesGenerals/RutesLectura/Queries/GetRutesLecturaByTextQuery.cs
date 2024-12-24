using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Queries
{
    public class GetRutesLecturaByTextQuery : IRequest<ResponseWrapper<List<ReadRutaLecturaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetRutesLecturaByTextQueryHandler : IRequestHandler<GetRutesLecturaByTextQuery, ResponseWrapper<List<ReadRutaLecturaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRutesLecturaByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadRutaLecturaDTO>>> Handle(GetRutesLecturaByTextQuery request, CancellationToken cancellationToken)
        {
            var rutesLecturaDb = await _unitOfWork.ReadRepositoryFor<RutaLectura>().GetByTextAsync(request.Text);

            if (rutesLecturaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadRutaLecturaDTO>>().Success(rutesLecturaDb.Adapt<List<ReadRutaLecturaDTO>>());
            }

            return new ResponseWrapper<List<ReadRutaLecturaDTO>>().Failure("No s'han trobat rutes!");
        }
    }
}
