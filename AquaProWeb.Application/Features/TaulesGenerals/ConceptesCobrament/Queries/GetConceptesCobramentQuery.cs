using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Queries
{
    public class GetConceptesCobramentQuery : IRequest<ResponseWrapper<List<ReadConcepteCobramentDTO>>>
    {
    }

    public class GetConceptesCobramentQueryHandler : IRequestHandler<GetConceptesCobramentQuery, ResponseWrapper<List<ReadConcepteCobramentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConceptesCobramentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> Handle(GetConceptesCobramentQuery request, CancellationToken cancellationToken)
        {
            var ConcepteCobramentDb = await _unitOfWork.ReadRepositoryFor<ConcepteCobrament>().GetAllAsync();

            if (ConcepteCobramentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadConcepteCobramentDTO>>().Success(ConcepteCobramentDb.Adapt<List<ReadConcepteCobramentDTO>>());
            }

            return new ResponseWrapper<List<ReadConcepteCobramentDTO>>().Failure("No hi han ConcepteCobrament!");
        }
    }
}
