using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Queries
{
    public class GetTipusIncidenciaUbicacioByIdQuery : IRequest<ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusIncidenciaUbicacioByIdQueryHandler : IRequestHandler<GetTipusIncidenciaUbicacioByIdQuery, ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaUbicacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>> Handle(GetTipusIncidenciaUbicacioByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().GetByIdAsync(request.Id);

            if (tipusIncidenciaUbicacioDb is not null)
            {
                var TipusIncidenciaUbicacioDTO = tipusIncidenciaUbicacioDb.Adapt<ReadTipusIncidenciaUbicacioDTO>();

                return new ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>().Success(TipusIncidenciaUbicacioDTO);
            }

            return new ResponseWrapper<ReadTipusIncidenciaUbicacioDTO>().Failure("TipusIncidenciaUbicacio no existeix!");
        }
    }
}
