using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Queries
{
    public class GetEscomesesQuery : IRequest<ResponseWrapper<List<ListEscomesaDTO>>>
    {
    }

    public class GetEscomesesQueryHandler : IRequestHandler<GetEscomesesQuery, ResponseWrapper<List<ListEscomesaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEscomesesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ListEscomesaDTO>>> Handle(GetEscomesesQuery request, CancellationToken cancellationToken)
        {
            var EscomesaDb = await _unitOfWork.ReadRepositoryFor<Escomesa>().GetAllAsync();

            if (EscomesaDb.Count > 0)
            {
                return new ResponseWrapper<List<ListEscomesaDTO>>().Success(EscomesaDb.Adapt<List<ListEscomesaDTO>>());
            }

            return new ResponseWrapper<List<ListEscomesaDTO>>().Failure("No hi han Punts de subministrament!");
        }
    }
}
