using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TipusVies.Commands
{
    public class CreateTipusViaCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusViaDTO CreateTipusVia { get; set; }
    }

    public class CreateTipusViaCommandHandler : IRequestHandler<CreateTipusViaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusViaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusViaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusVia = request.CreateTipusVia.Adapt<Domain.Entities.TipusVia>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusVia>().AddAsync(tipusVia);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusVia.Id, "TipusVia creat correctament!");
        }
    }
}
