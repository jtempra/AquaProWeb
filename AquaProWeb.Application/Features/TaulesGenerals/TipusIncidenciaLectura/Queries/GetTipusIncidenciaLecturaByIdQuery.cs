using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesLectures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaLectura.Queries
{
    public class GetTipusIncidenciaLecturaByIdQuery : IRequest<ResponseWrapper<ReadTipusIncidenciaLecturaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusIncidenciaLecturaByIdQueryHandler : IRequestHandler<GetTipusIncidenciaLecturaByIdQuery, ResponseWrapper<ReadTipusIncidenciaLecturaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaLecturaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusIncidenciaLecturaDTO>> Handle(GetTipusIncidenciaLecturaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaLecturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaLectura>().GetByIdAsync(request.Id);

            if (tipusIncidenciaLecturaDb is not null)
            {
                var TipusIncidenciaLecturaDTO = tipusIncidenciaLecturaDb.Adapt<ReadTipusIncidenciaLecturaDTO>();

                return new ResponseWrapper<ReadTipusIncidenciaLecturaDTO>().Success(TipusIncidenciaLecturaDTO);
            }

            return new ResponseWrapper<ReadTipusIncidenciaLecturaDTO>().Failure("TipusIncidenciaLectura no existeix!");
        }
    }
}
