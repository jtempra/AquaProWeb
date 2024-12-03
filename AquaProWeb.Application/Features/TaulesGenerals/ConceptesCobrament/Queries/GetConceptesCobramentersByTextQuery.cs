using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Queries
{
    public class GetConceptesCobramentersByTextQuery : IRequest<ResponseWrapper<List<ReadConcepteCobramentDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetConcepteCobramentByTextQueryHandler : IRequestHandler<GetConceptesCobramentersByTextQuery, ResponseWrapper<List<ReadConcepteCobramentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConcepteCobramentByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadConcepteCobramentDTO>>> Handle(GetConceptesCobramentersByTextQuery request, CancellationToken cancellationToken)
        {
            var ConcepteCobramentsDb = await _unitOfWork.ReadRepositoryFor<ConcepteCobrament>().GetByTextAsync(request.Text);

            if (ConcepteCobramentsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadConcepteCobramentDTO>>().Success(ConcepteCobramentsDb.Adapt<List<ReadConcepteCobramentDTO>>());
            }

            return new ResponseWrapper<List<ReadConcepteCobramentDTO>>().Failure("No s'han trobat ConcepteCobraments!");
        }
    }
}
