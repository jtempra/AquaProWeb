using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Queries
{
    public class GetTipusSuggerimentByTextQuery : IRequest<ResponseWrapper<List<ReadTipusSuggerimentDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetTipusSuggerimentByTextQueryHandler : IRequestHandler<GetTipusSuggerimentByTextQuery, ResponseWrapper<List<ReadTipusSuggerimentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusSuggerimentByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusSuggerimentDTO>>> Handle(GetTipusSuggerimentByTextQuery request, CancellationToken cancellationToken)
        {
            var tipusSuggerimentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusSuggeriment>().GetByTextAsync(request.Text);

            if (tipusSuggerimentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusSuggerimentDTO>>().Success(tipusSuggerimentDb.Adapt<List<ReadTipusSuggerimentDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusSuggerimentDTO>>().Failure("No s'han trobat TipusSuggeriment!");
        }
    }
}
