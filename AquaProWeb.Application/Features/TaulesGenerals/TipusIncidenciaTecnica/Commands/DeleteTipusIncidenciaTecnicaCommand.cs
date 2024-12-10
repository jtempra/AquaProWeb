using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaTecnica.Commands
{
    public class DeleteTipusIncidenciaTecnicaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusIncidenciaTecnicaCommandHandler : IRequestHandler<DeleteTipusIncidenciaTecnicaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusIncidenciaTecnicaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusIncidenciaTecnicaCommand Request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaTecnicaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().GetByIdAsync(Request.Id);

            if (tipusIncidenciaTecnicaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaTecnica>().DeleteAsync(tipusIncidenciaTecnicaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Tecnica esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaTecnica no trobat!");
        }
    }
}
