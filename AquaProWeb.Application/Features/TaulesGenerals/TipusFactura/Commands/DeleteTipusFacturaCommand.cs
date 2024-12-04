using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Commands
{
    public class DeleteTipusFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusFacturaCommandHandler : IRequestHandler<DeleteTipusFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusFacturaCommand Request, CancellationToken cancellationToken)
        {
            var tipusFacturaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusFactura>().GetByIdAsync(Request.Id);

            if (tipusFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusFactura>().DeleteAsync(tipusFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusFactura no trobat!");
        }
    }
}
