using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Commands
{
    public class DeleteMotiuBaixaTitularCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMotiuBaixaTitularCommandHandler : IRequestHandler<DeleteMotiuBaixaTitularCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotiuBaixaTitularCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteMotiuBaixaTitularCommand Request, CancellationToken cancellationToken)
        {
            var motiuBaixaTitularDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaTitular>().GetByIdAsync(Request.Id);

            if (motiuBaixaTitularDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<MotiuBaixaTitular>().DeleteAsync(motiuBaixaTitularDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Motiu baixa Titular no trobat!");
        }
    }
}
