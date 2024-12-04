using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.SituacionsRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Queries
{
    public class GetSituacioRebutByIdQuery : IRequest<ResponseWrapper<ReadSituacioRebutDTO>>
    {
        public int Id { get; set; }
    }

    public class GetSituacioRebutByIdQueryHandler : IRequestHandler<GetSituacioRebutByIdQuery, ResponseWrapper<ReadSituacioRebutDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSituacioRebutByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadSituacioRebutDTO>> Handle(GetSituacioRebutByIdQuery request, CancellationToken cancellationToken)
        {
            var situacioRebutDb = await _unitOfWork.ReadRepositoryFor<SituacioRebut>().GetByIdAsync(request.Id);

            if (situacioRebutDb is not null)
            {
                var SituacioRebutDTO = situacioRebutDb.Adapt<ReadSituacioRebutDTO>();

                return new ResponseWrapper<ReadSituacioRebutDTO>().Success(SituacioRebutDTO);
            }

            return new ResponseWrapper<ReadSituacioRebutDTO>().Failure("SituacioRebut no existeix!");
        }
    }
}
