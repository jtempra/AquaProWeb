using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Queries
{
    public class GetTipusSuggerimentQuery : IRequest<ResponseWrapper<List<ReadTipusSuggerimentDTO>>>
    {
    }

    public class GetTipusSuggerimentQueryHandler : IRequestHandler<GetTipusSuggerimentQuery, ResponseWrapper<List<ReadTipusSuggerimentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusSuggerimentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusSuggerimentDTO>>> Handle(GetTipusSuggerimentQuery request, CancellationToken cancellationToken)
        {
            var tipusSuggerimentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusSuggeriment>().GetAllAsync();

            if (tipusSuggerimentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusSuggerimentDTO>>().Success(tipusSuggerimentDb.Adapt<List<ReadTipusSuggerimentDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusSuggerimentDTO>>().Failure("No hi han TipusSuggeriment!");
        }
    }
}
