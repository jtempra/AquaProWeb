using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Commands
{
    public class DeleteTipusConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusConcepteFacturaCommandHandler : IRequestHandler<DeleteTipusConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusConcepteFacturaCommand Request, CancellationToken cancellationToken)
        {
            var tipusConcepteFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusConcepteFactura>().GetByIdAsync(Request.Id);

            if (tipusConcepteFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusConcepteFactura>().DeleteAsync(tipusConcepteFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusConcepteFactura no trobat!");
        }
    }
}
