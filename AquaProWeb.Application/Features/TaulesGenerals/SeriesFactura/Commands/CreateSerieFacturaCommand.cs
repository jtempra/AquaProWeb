using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SeriesFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Commands
{
    public class CreateSerieFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveSerieFacturaDTO CreateSerieFactura { get; set; }
    }

    public class CreateSerieFacturaCommandHandler : IRequestHandler<CreateSerieFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSerieFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateSerieFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var serieFactura = request.CreateSerieFactura.Adapt<SerieFactura>();

            await _unitOfWork.WriteRepositoryFor<SerieFactura>().AddAsync(serieFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(serieFactura.Id, "SerieFactura creat correctament!");
        }
    }
}
