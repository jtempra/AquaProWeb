using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Queries
{
    public class GetTipusQueixaQuery : IRequest<ResponseWrapper<List<ReadTipusQueixaDTO>>>
    {
    }

    public class GetTipusQueixaQueryHandler : IRequestHandler<GetTipusQueixaQuery, ResponseWrapper<List<ReadTipusQueixaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusQueixaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusQueixaDTO>>> Handle(GetTipusQueixaQuery request, CancellationToken cancellationToken)
        {
            var tipusQueixaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusQueixa>().GetAllAsync();

            if (tipusQueixaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusQueixaDTO>>().Success(tipusQueixaDb.Adapt<List<ReadTipusQueixaDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusQueixaDTO>>().Failure("No hi han TipusQueixa!");
        }
    }
}
