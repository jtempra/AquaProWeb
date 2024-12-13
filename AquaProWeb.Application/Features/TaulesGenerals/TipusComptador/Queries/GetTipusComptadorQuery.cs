using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Queries
{
    public class GetTipusComptadorQuery : IRequest<ResponseWrapper<List<ReadTipusComptadorDTO>>>
    {
    }

    public class GetTipusComptadorQueryHandler : IRequestHandler<GetTipusComptadorQuery, ResponseWrapper<List<ReadTipusComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusComptadorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusComptadorDTO>>> Handle(GetTipusComptadorQuery request, CancellationToken cancellationToken)
        {
            var tipusComptadorDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusComptador>().GetAllAsync();

            if (tipusComptadorDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusComptadorDTO>>().Success(tipusComptadorDb.Adapt<List<ReadTipusComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusComptadorDTO>>().Failure("No hi han TipusComptador!");
        }
    }
}
