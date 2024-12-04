using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Commands
{
    public class DeleteSituacioFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSituacioFacturaCommandHandler : IRequestHandler<DeleteSituacioFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSituacioFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteSituacioFacturaCommand Request, CancellationToken cancellationToken)
        {
            var situacioFacturaDb = await _unitOfWork.ReadRepositoryFor<SituacioFactura>().GetByIdAsync(Request.Id);

            if (situacioFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<SituacioFactura>().DeleteAsync(situacioFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "SituacioFactura creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SituacioFactura no trobat!");
        }
    }
}
