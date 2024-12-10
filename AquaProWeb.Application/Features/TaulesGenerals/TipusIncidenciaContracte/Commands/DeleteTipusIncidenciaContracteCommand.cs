using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Commands
{
    public class DeleteTipusIncidenciaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusIncidenciaContracteCommandHandler : IRequestHandler<DeleteTipusIncidenciaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusIncidenciaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusIncidenciaContracteCommand Request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().GetByIdAsync(Request.Id);

            if (tipusIncidenciaContracteDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().DeleteAsync(tipusIncidenciaContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Contracte esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaContracte no trobat!");
        }
    }
}
