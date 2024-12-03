using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SeriesFactura.Commands
{
    public class DeleteSerieFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteSerieFacturaCommandHandler : IRequestHandler<DeleteSerieFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSerieFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteSerieFacturaCommand Request, CancellationToken cancellationToken)
        {
            var serieFacturaDb = await _unitOfWork.ReadRepositoryFor<SerieFactura>().GetByIdAsync(Request.Id);

            if (serieFacturaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<SerieFactura>().DeleteAsync(serieFacturaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "SerieFactura creat correctament!");
            }

            return new ResponseWrapper<int>().Failure("SerieFactura no trobat!");
        }
    }
}
