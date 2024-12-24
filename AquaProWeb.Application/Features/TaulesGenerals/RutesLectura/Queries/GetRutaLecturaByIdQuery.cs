using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.RutesLectura.Queries
{
    public class GetRutaLecturaByIdQuery : IRequest<ResponseWrapper<ReadRutaLecturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetRutaLecturaByIdQueryHandler : IRequestHandler<GetRutaLecturaByIdQuery, ResponseWrapper<ReadRutaLecturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRutaLecturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadRutaLecturaDTO>> Handle(GetRutaLecturaByIdQuery request, CancellationToken cancellationToken)
        {
            var rutaLecturaDb = await _unitOfWork.ReadRepositoryFor<RutaLectura>().GetByIdAsync(request.Id);

            if (rutaLecturaDb is not null)
            {
                return new ResponseWrapper<ReadRutaLecturaDTO>().Success(rutaLecturaDb.Adapt<ReadRutaLecturaDTO>());
            }

            return new ResponseWrapper<ReadRutaLecturaDTO>().Failure("La poblacio no existeix!");
        }
    }
}
