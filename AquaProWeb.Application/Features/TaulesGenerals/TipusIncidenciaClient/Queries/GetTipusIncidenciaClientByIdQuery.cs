using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesClients;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Queries
{
    public class GetTipusIncidenciaClientByIdQuery : IRequest<ResponseWrapper<ReadTipusIncidenciaClientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusIncidenciaClientByIdQueryHandler : IRequestHandler<GetTipusIncidenciaClientByIdQuery, ResponseWrapper<ReadTipusIncidenciaClientDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusIncidenciaClientDTO>> Handle(GetTipusIncidenciaClientByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaClient>().GetByIdAsync(request.Id);

            if (tipusIncidenciaClientDb is not null)
            {
                var TipusIncidenciaClientDTO = tipusIncidenciaClientDb.Adapt<ReadTipusIncidenciaClientDTO>();

                return new ResponseWrapper<ReadTipusIncidenciaClientDTO>().Success(TipusIncidenciaClientDTO);
            }

            return new ResponseWrapper<ReadTipusIncidenciaClientDTO>().Failure("TipusIncidenciaClient no existeix!");
        }
    }
}
