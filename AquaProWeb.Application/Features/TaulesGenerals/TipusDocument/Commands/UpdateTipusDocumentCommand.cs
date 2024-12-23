using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusDocuments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Commands
{
    public class UpdateTipusDocumentCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusDocumentDTO UpdateTipusDocument { get; set; }
    }

    public class UpdateTipusDocumentCommandHandler : IRequestHandler<UpdateTipusDocumentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusDocumentCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusDocumentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusDocument>().GetByIdAsync(request.UpdateTipusDocument.Id);

            if (tipusDocumentDb is not null)
            {
                request.UpdateTipusDocument.Adapt(tipusDocumentDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusDocument>().UpdateAsync(tipusDocumentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusDocumentDb.Id, "TipusDocument actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusDocument no existeix!");

        }
    }
}
