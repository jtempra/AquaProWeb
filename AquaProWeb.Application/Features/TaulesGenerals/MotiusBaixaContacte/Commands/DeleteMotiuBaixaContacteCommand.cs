using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Commands
{
    public class DeleteMotiuBaixaContacteCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMotiuBaixaContacteCommandHandler : IRequestHandler<DeleteMotiuBaixaContacteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotiuBaixaContacteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteMotiuBaixaContacteCommand Request, CancellationToken cancellationToken)
        {
            var motiuBaixaContacteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaContacte>().GetByIdAsync(Request.Id);

            if (motiuBaixaContacteDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<MotiuBaixaContacte>().DeleteAsync(motiuBaixaContacteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Motiu baixa Contacte no trobat!");
        }
    }
}
