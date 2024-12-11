using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusSuggeriment.Commands
{
    public class DeleteTipusSuggerimentCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusSuggerimentCommandHandler : IRequestHandler<DeleteTipusSuggerimentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusSuggerimentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusSuggerimentCommand Request, CancellationToken cancellationToken)
        {
            var tipusSuggerimentDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusSuggeriment>().GetByIdAsync(Request.Id);

            if (tipusSuggerimentDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusSuggeriment>().DeleteAsync(tipusSuggerimentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusSuggeriment no trobat!");
        }
    }
}
