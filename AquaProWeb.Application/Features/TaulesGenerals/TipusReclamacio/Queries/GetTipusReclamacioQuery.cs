using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Queries
{
    public class GetTipusReclamacioQuery : IRequest<ResponseWrapper<List<ReadTipusReclamacioDTO>>>
    {
    }

    public class GetTipusReclamacioQueryHandler : IRequestHandler<GetTipusReclamacioQuery, ResponseWrapper<List<ReadTipusReclamacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusReclamacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusReclamacioDTO>>> Handle(GetTipusReclamacioQuery request, CancellationToken cancellationToken)
        {
            var tipusReclamacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusReclamacio>().GetAllAsync();

            if (tipusReclamacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusReclamacioDTO>>().Success(tipusReclamacioDb.Adapt<List<ReadTipusReclamacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusReclamacioDTO>>().Failure("No hi han TipusReclamacio!");
        }
    }
}
