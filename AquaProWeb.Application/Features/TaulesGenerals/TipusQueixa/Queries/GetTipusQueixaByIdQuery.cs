using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Queries
{
    public class GetTipusQueixaByIdQuery : IRequest<ResponseWrapper<ReadTipusQueixaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusQueixaByIdQueryHandler : IRequestHandler<GetTipusQueixaByIdQuery, ResponseWrapper<ReadTipusQueixaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusQueixaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusQueixaDTO>> Handle(GetTipusQueixaByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusQueixaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusQueixa>().GetByIdAsync(request.Id);

            if (tipusQueixaDb is not null)
            {
                var TipusQueixaDTO = tipusQueixaDb.Adapt<ReadTipusQueixaDTO>();

                return new ResponseWrapper<ReadTipusQueixaDTO>().Success(TipusQueixaDTO);
            }

            return new ResponseWrapper<ReadTipusQueixaDTO>().Failure("TipusQueixa no existeix!");
        }
    }
}
