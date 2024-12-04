using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Commands
{
    public class CreateTipusDocumentCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusDocumentDTO CreateTipusDocument { get; set; }
    }

    public class CreateTipusDocumentCommandHandler : IRequestHandler<CreateTipusDocumentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusDocumentCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusDocument = request.CreateTipusDocument.Adapt<Domain.Entities.TipusDocument>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusDocument>().AddAsync(tipusDocument);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusDocument.Id, "TipusDocument creat correctament!");
        }
    }
}
