using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusOrdresTreball;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusOrdreTreball.Queries
{
    public class GetTipusOrdreTreballByIdQuery : IRequest<ResponseWrapper<ReadTipusOrdreTreballDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusOrdreTreballByIdQueryHandler : IRequestHandler<GetTipusOrdreTreballByIdQuery, ResponseWrapper<ReadTipusOrdreTreballDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusOrdreTreballByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusOrdreTreballDTO>> Handle(GetTipusOrdreTreballByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusOrdreTreballDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusOrdreTreball>().GetByIdAsync(request.Id);

            if (tipusOrdreTreballDb is not null)
            {
                var TipusOrdreTreballDTO = tipusOrdreTreballDb.Adapt<ReadTipusOrdreTreballDTO>();

                return new ResponseWrapper<ReadTipusOrdreTreballDTO>().Success(TipusOrdreTreballDTO);
            }

            return new ResponseWrapper<ReadTipusOrdreTreballDTO>().Failure("TipusOrdreTreball no existeix!");
        }
    }
}
