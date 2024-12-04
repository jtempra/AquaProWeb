using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusBaixaClient.Commands
{
    public class DeleteTipusBaixaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusBaixaClientCommandHandler : IRequestHandler<DeleteTipusBaixaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusBaixaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusBaixaClientCommand Request, CancellationToken cancellationToken)
        {
            var tipusBaixaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusBaixaClient>().GetByIdAsync(Request.Id);

            if (tipusBaixaClientDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusBaixaClient>().DeleteAsync(tipusBaixaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusBaixaClient no trobat!");
        }
    }
}
