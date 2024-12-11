using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Commands
{
    public class CreateTipusSuggerimentCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateTipusSuggerimentDTO CreateTipusSuggeriment { get; set; }
    }

    public class CreateTipusSuggerimentCommandHandler : IRequestHandler<CreateTipusSuggerimentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTipusSuggerimentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateTipusSuggerimentCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var tipusSuggeriment = request.CreateTipusSuggeriment.Adapt<Domain.Entities.TipusSuggeriment>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusSuggeriment>().AddAsync(tipusSuggeriment);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(tipusSuggeriment.Id, "TipusSuggeriment creat correctament!");
        }
    }
}
