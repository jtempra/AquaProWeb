using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaUbicacio.Commands
{
    public class DeleteTipusIncidenciaUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipusIncidenciaUbicacioCommandHandler : IRequestHandler<DeleteTipusIncidenciaUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTipusIncidenciaUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteTipusIncidenciaUbicacioCommand Request, CancellationToken cancellationToken)
        {
            var tipusIncidenciaUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().GetByIdAsync(Request.Id);

            if (tipusIncidenciaUbicacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaUbicacio>().DeleteAsync(tipusIncidenciaUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Tipus Baixa Ubicacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaUbicacio no trobat!");
        }
    }
}
