using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioFactura;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsFactura.Commands
{
    public class CreateSituacioFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveSituacioFacturaDTO CreateSituacioFactura { get; set; }
    }

    public class CreateSituacioFacturaCommandHandler : IRequestHandler<CreateSituacioFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSituacioFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateSituacioFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var situacioFactura = request.CreateSituacioFactura.Adapt<SituacioFactura>();

            await _unitOfWork.WriteRepositoryFor<SituacioFactura>().AddAsync(situacioFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(situacioFactura.Id, "SituacioFactura creat correctament!");
        }
    }
}
