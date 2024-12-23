using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusSuggeriments;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Commands
{
    public class UpdateTipusSuggerimentCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusSuggerimentDTO UpdateTipusSuggeriment { get; set; }
    }

    public class UpdateTipusSuggerimentCommandHandler : IRequestHandler<UpdateTipusSuggerimentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusSuggerimentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusSuggerimentCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusSuggerimentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusSuggeriment>().GetByIdAsync(request.UpdateTipusSuggeriment.Id);

            if (tipusSuggerimentDb is not null)
            {
                request.UpdateTipusSuggeriment.Adapt(tipusSuggerimentDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusSuggeriment>().UpdateAsync(tipusSuggerimentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusSuggerimentDb.Id, "TipusSuggeriment actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusSuggeriment no existeix!");

        }
    }
}
