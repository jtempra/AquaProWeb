using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Commands
{
    public class DeleteMotiuBaixaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMotiuBaixaComptadorCommandHandler : IRequestHandler<DeleteMotiuBaixaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMotiuBaixaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteMotiuBaixaComptadorCommand Request, CancellationToken cancellationToken)
        {
            var motiuBaixaComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaComptador>().GetByIdAsync(Request.Id);

            if (motiuBaixaComptadorDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<MotiuBaixaComptador>().DeleteAsync(motiuBaixaComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Motiu baixa comptador no trobat!");
        }
    }
}
