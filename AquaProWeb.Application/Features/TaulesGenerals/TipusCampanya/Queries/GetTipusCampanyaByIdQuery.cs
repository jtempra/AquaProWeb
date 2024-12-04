using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Queries
{
    public class GetTipusCampanyaByIdQuery : IRequest<ResponseWrapper<ReadTipusCampanyaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusCampanyaByIdQueryHandler : IRequestHandler<GetTipusCampanyaByIdQuery, ResponseWrapper<ReadTipusCampanyaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusCampanyaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusCampanyaDTO>> Handle(GetTipusCampanyaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusCampanyaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusCampanya>().GetByIdAsync(request.Id);

            if (tipusCampanyaDb is not null)
            {
                var TipusCampanyaDTO = tipusCampanyaDb.Adapt<ReadTipusCampanyaDTO>();

                return new ResponseWrapper<ReadTipusCampanyaDTO>().Success(TipusCampanyaDTO);
            }

            return new ResponseWrapper<ReadTipusCampanyaDTO>().Failure("TipusCampanya no existeix!");
        }
    }
}
