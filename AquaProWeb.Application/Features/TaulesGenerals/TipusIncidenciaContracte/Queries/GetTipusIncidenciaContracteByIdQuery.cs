using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Queries
{
    public class GetTipusIncidenciaContracteByIdQuery : IRequest<ResponseWrapper<ReadTipusIncidenciaContracteDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusIncidenciaContracteByIdQueryHandler : IRequestHandler<GetTipusIncidenciaContracteByIdQuery, ResponseWrapper<ReadTipusIncidenciaContracteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusIncidenciaContracteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusIncidenciaContracteDTO>> Handle(GetTipusIncidenciaContracteByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().GetByIdAsync(request.Id);

            if (tipusIncidenciaContracteDb is not null)
            {
                var TipusIncidenciaContracteDTO = tipusIncidenciaContracteDb.Adapt<ReadTipusIncidenciaContracteDTO>();

                return new ResponseWrapper<ReadTipusIncidenciaContracteDTO>().Success(TipusIncidenciaContracteDTO);
            }

            return new ResponseWrapper<ReadTipusIncidenciaContracteDTO>().Failure("TipusIncidenciaContracte no existeix!");
        }
    }
}
