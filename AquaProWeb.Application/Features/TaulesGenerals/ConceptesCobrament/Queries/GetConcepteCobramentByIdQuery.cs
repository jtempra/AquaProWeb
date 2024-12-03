using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Queries
{
    public class GetConcepteCobramentByIdQuery : IRequest<ResponseWrapper<ReadConcepteCobramentDTO>>
    {
        public int Id { get; set; }
    }

    public class GetConcepteCobramentByIdQueryHandler : IRequestHandler<GetConcepteCobramentByIdQuery, ResponseWrapper<ReadConcepteCobramentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConcepteCobramentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadConcepteCobramentDTO>> Handle(GetConcepteCobramentByIdQuery request, CancellationToken cancellationToken)
        {
            var ConcepteCobramentDb = await _unitOfWork.ReadRepositoryFor<ConcepteCobrament>().GetByIdAsync(request.Id);

            if (ConcepteCobramentDb is not null)
            {
                var ConcepteCobramentDTO = ConcepteCobramentDb.Adapt<ReadConcepteCobramentDTO>();

                return new ResponseWrapper<ReadConcepteCobramentDTO>().Success(ConcepteCobramentDTO);
            }

            return new ResponseWrapper<ReadConcepteCobramentDTO>().Failure("El ConcepteCobrament no existeix!");
        }
    }
}
