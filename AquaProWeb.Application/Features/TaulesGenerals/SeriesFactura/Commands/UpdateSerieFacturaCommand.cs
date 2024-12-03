using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Commands
{
    public class UpdateSerieFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateSerieFacturaDTO UpdateSerieFactura { get; set; }
    }

    public class UpdateSerieFacturaCommandHandler : IRequestHandler<UpdateSerieFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSerieFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateSerieFacturaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var serieFacturaDb = await _unitOfWork.ReadRepositoryFor<SerieFactura>().GetByIdAsync(request.UpdateSerieFactura.Id);

            if (serieFacturaDb is not null)
            {
                request.UpdateSerieFactura.Adapt(serieFacturaDb);

                await _unitOfWork.WriteRepositoryFor<SerieFactura>().UpdateAsync(serieFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(serieFacturaDb.Id, "SerieFactura actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SerieFactura no existeix!");

        }
    }
}
