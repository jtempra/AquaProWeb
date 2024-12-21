using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Queries
{
    public class GetUbicacioByIdQuery : IRequest<ResponseWrapper<ReadUbicacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetUbicacioByIdQueryHandler : IRequestHandler<GetUbicacioByIdQuery, ResponseWrapper<ReadUbicacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUbicacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadUbicacioDTO>> Handle(GetUbicacioByIdQuery request, CancellationToken cancellationToken)
        {
            var UbicacioDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByIdAsync(request.Id, t => t.Tipus, z => z.Zona, p => p.Poblacio, c => c.Carrer, e => e.Escomesa, r => r.RutaLectura);

            if (UbicacioDb is not null)
            {
                var UbicacioDTO = UbicacioDb.Adapt<ReadUbicacioDTO>();

                return new ResponseWrapper<ReadUbicacioDTO>().Success(UbicacioDTO);
            }

            return new ResponseWrapper<ReadUbicacioDTO>().Failure("El Ubicacio no existeix!");
        }
    }
}
