using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.PuntsSubministrament.Queries
{
    public class GetUbicacionsQuery : IRequest<ResponseWrapper<List<ReadUbicacioDTO>>>
    {
    }

    public class GetUbicacionsQueryHandler : IRequestHandler<GetUbicacionsQuery, ResponseWrapper<List<ReadUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUbicacionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadUbicacioDTO>>> Handle(GetUbicacionsQuery request, CancellationToken cancellationToken)
        {
            var UbicacioDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetAllAsync(t => t.Tipus, z => z.Zona, p => p.Poblacio, c => c.Carrer, e => e.Escomesa, r => r.RutaLectura);

            if (UbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadUbicacioDTO>>().Success(UbicacioDb.Adapt<List<ReadUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadUbicacioDTO>>().Failure("No hi han Punts de subministrament!");
        }
    }
}
