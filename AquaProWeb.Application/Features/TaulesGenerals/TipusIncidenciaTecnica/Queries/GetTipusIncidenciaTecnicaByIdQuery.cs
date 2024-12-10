using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesTecniques;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Queries
{
    public class GetTipusIncidenciaTecnicaByIdQuery : IRequest<ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusIncidenciaTecnicaByIdQueryHandler : IRequestHandler<GetTipusIncidenciaTecnicaByIdQuery, ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaTecnicaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>> Handle(GetTipusIncidenciaTecnicaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaTecnicaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().GetByIdAsync(request.Id);

            if (tipusIncidenciaTecnicaDb is not null)
            {
                var TipusIncidenciaTecnicaDTO = tipusIncidenciaTecnicaDb.Adapt<ReadTipusIncidenciaTecnicaDTO>();

                return new ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>().Success(TipusIncidenciaTecnicaDTO);
            }

            return new ResponseWrapper<ReadTipusIncidenciaTecnicaDTO>().Failure("TipusIncidenciaTecnica no existeix!");
        }
    }
}
