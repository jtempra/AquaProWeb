using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaClient.Commands
{
    public class DeleteTipusIncidenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusIncidenciaClientCommandHandler : IRequestHandler<DeleteTipusIncidenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusIncidenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusIncidenciaClientCommand Request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaClientDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaClient>().GetByIdAsync(Request.Id);

            if (tipusIncidenciaClientDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaClient>().DeleteAsync(tipusIncidenciaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Client esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaClient no trobat!");
        }
    }
}
