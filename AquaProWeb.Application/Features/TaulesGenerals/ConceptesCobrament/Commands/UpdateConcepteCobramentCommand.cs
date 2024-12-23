using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ConceptesCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Commands
{
    public class UpdateConcepteCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveConcepteCobramentDTO UpdateConcepteCobrament { get; set; }
    }

    public class UpdateConcepteCobramentCommandHandler : IRequestHandler<UpdateConcepteCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateConcepteCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateConcepteCobramentCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var concepteCobramentDb = await _unitOfWork.ReadRepositoryFor<ConcepteCobrament>().GetByIdAsync(request.UpdateConcepteCobrament.Id);

            if (concepteCobramentDb is not null)
            {
                request.UpdateConcepteCobrament.Adapt(concepteCobramentDb);

                await _unitOfWork.WriteRepositoryFor<ConcepteCobrament>().UpdateAsync(concepteCobramentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(concepteCobramentDb.Id, "ConcepteCobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El ConcepteCobrament no existeix!");

        }
    }
}
