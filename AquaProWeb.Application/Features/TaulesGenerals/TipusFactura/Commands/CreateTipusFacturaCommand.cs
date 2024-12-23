using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusFactures;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusFactura.Commands
{
    public class CreateTipusFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusFacturaDTO CreateTipusFactura { get; set; }
    }

    public class CreateTipusFacturaCommandHandler : IRequestHandler<CreateTipusFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusFactura = request.CreateTipusFactura.Adapt<Domain.Entities.TipusFactura>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusFactura>().AddAsync(tipusFactura);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusFactura.Id, "TipusFactura creat correctament!");
        }
    }
}
