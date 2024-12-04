using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Commands
{
    public class UpdateSituacioFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateSituacioFacturaDTO UpdateSituacioFactura { get; set; }
    }

    public class UpdateSituacioFacturaCommandHandler : IRequestHandler<UpdateSituacioFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSituacioFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateSituacioFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var situacioFacturaDb = await _unitOfWork.ReadRepositoryFor<SituacioFactura>().GetByIdAsync(request.UpdateSituacioFactura.Id);

            if (situacioFacturaDb is not null)
            {
                request.UpdateSituacioFactura.Adapt(situacioFacturaDb);

                await _unitOfWork.WriteRepositoryFor<SituacioFactura>().UpdateAsync(situacioFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(situacioFacturaDb.Id, "SituacioFactura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SituacioFactura no existeix!");

        }
    }
}
