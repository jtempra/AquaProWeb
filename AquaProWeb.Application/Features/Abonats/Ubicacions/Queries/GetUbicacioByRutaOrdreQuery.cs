using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Queries
{
    public class GetUbicacioByRutaOrdreQuery : IRequest<ResponseWrapper<ReadUbicacioDTO>>
    {
        public int IdRuta { get; set; }
        public int Ordre { get; set; }
    }

    public class GetUbicacioByRutaOrdreQueryHandler : IRequestHandler<GetUbicacioByRutaOrdreQuery, ResponseWrapper<ReadUbicacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUbicacioByRutaOrdreQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadUbicacioDTO>> Handle(GetUbicacioByRutaOrdreQuery request, CancellationToken cancellationToken)
        {
            var UbicacionsDb = _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByPredicateAsync(c => c.RutaLecturaId == request.IdRuta && c.OrdreRutaLectura == request.Ordre, t => t.Tipus, z => z.Zona, p => p.Poblacio, c => c.Carrer, e => e.Escomesa, r => r.RutaLectura);

            if (UbicacionsDb.Count > 0)
            {
                var UbicacioDTO = UbicacionsDb.First().Adapt<ReadUbicacioDTO>();

                return new ResponseWrapper<ReadUbicacioDTO>().Success(UbicacioDTO);
            }

            return new ResponseWrapper<ReadUbicacioDTO>().Failure("El Ubicacio no existeix!");
        }
    }
}
