using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusConceptesFactura;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusConcepteFactura.Commands
{
    public class CreateTipusConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusConcepteFacturaDTO CreateTipusConcepteFactura { get; set; }
    }

    public class CreateTipusConcepteFacturaCommandHandler : IRequestHandler<CreateTipusConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusConcepteFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusConcepteFactura = request.CreateTipusConcepteFactura.Adapt<Domain.Entities.TipusConcepteFactura>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusConcepteFactura>().AddAsync(tipusConcepteFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusConcepteFactura.Id, "TipusConcepteFactura creat correctament!");
        }
    }
}
