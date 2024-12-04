using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusDocument.Commands
{
    public class DeleteTipusDocumentCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusDocumentCommandHandler : IRequestHandler<DeleteTipusDocumentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusDocumentCommand Request, CancellationToken cancellationToken)
        {
            var tipusDocumentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusDocument>().GetByIdAsync(Request.Id);

            if (tipusDocumentDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusDocument>().DeleteAsync(tipusDocumentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusDocument no trobat!");
        }
    }
}
