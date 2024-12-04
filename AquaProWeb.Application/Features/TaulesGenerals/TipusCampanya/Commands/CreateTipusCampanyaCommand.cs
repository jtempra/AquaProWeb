using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusCampanyes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusCampanya.Commands
{
    public class CreateTipusCampanyaCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusCampanyaDTO CreateTipusCampanya { get; set; }
    }

    public class CreateTipusCampanyaCommandHandler : IRequestHandler<CreateTipusCampanyaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusCampanyaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusCampanyaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusCampanya = request.CreateTipusCampanya.Adapt<Domain.Entities.TipusCampanya>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusCampanya>().AddAsync(tipusCampanya);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusCampanya.Id, "TipusCampanya creat correctament!");
        }
    }
}
