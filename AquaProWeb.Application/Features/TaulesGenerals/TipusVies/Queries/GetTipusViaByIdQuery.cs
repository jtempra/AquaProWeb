using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusVies.Queries
{
    public class GetTipusViaByIdQuery : IRequest<ResponseWrapper<ReadTipusViaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusViaByIdQueryHandler : IRequestHandler<GetTipusViaByIdQuery, ResponseWrapper<ReadTipusViaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusViaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusViaDTO>> Handle(GetTipusViaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusViaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusVia>().GetByIdAsync(request.Id);

            if (tipusViaDb is not null)
            {
                return new ResponseWrapper<ReadTipusViaDTO>().Success(tipusViaDb.Adapt<ReadTipusViaDTO>());
            }

            return new ResponseWrapper<ReadTipusViaDTO>().Failure("El tipus de via no existeix!");
        }
    }
}
