using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Commands
{
    public class CreateConcepteCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateConcepteCobramentDTO CreateConcepteCobrament { get; set; }
    }

    public class CreateConcepteCobramentCommandHandler : IRequestHandler<CreateConcepteCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateConcepteCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateConcepteCobramentCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var concepteCobrament = request.CreateConcepteCobrament.Adapt<ConcepteCobrament>();

            await _unitOfWork.WriteRepositoryFor<ConcepteCobrament>().AddAsync(concepteCobrament);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(concepteCobrament.Id, "ConcepteCobrament creat correctament!");
        }
    }
}
