using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Queries
{
    public class GetEscomesesByTextQuery : IRequest<ResponseWrapper<List<ListEscomesaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetEscomesesByTextQueryHandler : IRequestHandler<GetEscomesesByTextQuery, ResponseWrapper<List<ListEscomesaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEscomesesByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ListEscomesaDTO>>> Handle(GetEscomesesByTextQuery request, CancellationToken cancellationToken)
        {
            var EscomesesDb = await _unitOfWork.ReadRepositoryFor<Escomesa>().GetByTextAsync(request.Text);

            if (EscomesesDb.Count > 0)
            {
                return new ResponseWrapper<List<ListEscomesaDTO>>().Success(EscomesesDb.Adapt<List<ListEscomesaDTO>>());
            }

            return new ResponseWrapper<List<ListEscomesaDTO>>().Failure("No s'han trobat Escomeses!");
        }
    }
}
