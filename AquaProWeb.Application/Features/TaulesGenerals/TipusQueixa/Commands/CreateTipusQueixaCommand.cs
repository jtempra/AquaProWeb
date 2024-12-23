using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Commands
{
    public class CreateTipusQueixaCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusQueixaDTO CreateTipusQueixa { get; set; }
    }

    public class CreateTipusQueixaCommandHandler : IRequestHandler<CreateTipusQueixaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusQueixaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusQueixaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusQueixa = request.CreateTipusQueixa.Adapt<Domain.Entities.TipusQueixa>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusQueixa>().AddAsync(tipusQueixa);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusQueixa.Id, "TipusQueixa creat correctament!");
        }
    }
}
