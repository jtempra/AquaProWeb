using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusClient.Commands
{
    public class DeleteTipusClientCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusClientCommandHandler : IRequestHandler<DeleteTipusClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusClientCommand Request, CancellationToken cancellationToken)
        {
            var tipusClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusClient>().GetByIdAsync(Request.Id);

            if (tipusClientDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusClient>().DeleteAsync(tipusClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusClient no trobat!");
        }
    }
}
