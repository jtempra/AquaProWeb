using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusIncidenciesContractes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusIncidenciaContracte.Commands
{
    public class UpdateTipusIncidenciaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveTipusIncidenciaContracteDTO UpdateTipusIncidenciaContracte { get; set; }
    }

    public class UpdateTipusIncidenciaContracteCommandHandler : IRequestHandler<UpdateTipusIncidenciaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusIncidenciaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusIncidenciaContracteCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusIncidenciaContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().GetByIdAsync(request.UpdateTipusIncidenciaContracte.Id);

            if (tipusIncidenciaContracteDb is not null)
            {
                request.UpdateTipusIncidenciaContracte.Adapt(tipusIncidenciaContracteDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusIncidenciaContracte>().UpdateAsync(tipusIncidenciaContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusIncidenciaContracteDb.Id, "TipusIncidenciaContracte actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusIncidenciaContracte no existeix!");

        }
    }
}
