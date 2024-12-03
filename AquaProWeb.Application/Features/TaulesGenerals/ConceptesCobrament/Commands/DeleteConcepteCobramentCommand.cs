using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ConceptesCobrament.Commands
{
    public class DeleteConcepteCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteConcepteCobramentCommandHandler : IRequestHandler<DeleteConcepteCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConcepteCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteConcepteCobramentCommand Request, CancellationToken cancellationToken)
        {
            var concepteCobramentDb = await _unitOfWork.ReadRepositoryFor<ConcepteCobrament>().GetByIdAsync(Request.Id);

            if (concepteCobramentDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<ConcepteCobrament>().DeleteAsync(concepteCobramentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(concepteCobramentDb.Id, "ConcepteCobrament esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("ConcepteCobrament no trobat!");
        }
    }
}
