using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Queries
{
    public class GetTipusUbicacioByIdQuery : IRequest<ResponseWrapper<ReadTipusUbicacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusUbicacioByIdQueryHandler : IRequestHandler<GetTipusUbicacioByIdQuery, ResponseWrapper<ReadTipusUbicacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusUbicacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusUbicacioDTO>> Handle(GetTipusUbicacioByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusUbicacio>().GetByIdAsync(request.Id);

            if (tipusUbicacioDb is not null)
            {
                var TipusUbicacioDTO = tipusUbicacioDb.Adapt<ReadTipusUbicacioDTO>();

                return new ResponseWrapper<ReadTipusUbicacioDTO>().Success(TipusUbicacioDTO);
            }

            return new ResponseWrapper<ReadTipusUbicacioDTO>().Failure("TipusUbicacio no existeix!");
        }
    }
}
