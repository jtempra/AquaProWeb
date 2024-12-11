using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Commands
{
    public class UpdateTipusUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusUbicacioDTO UpdateTipusUbicacio { get; set; }
    }

    public class UpdateTipusUbicacioCommandHandler : IRequestHandler<UpdateTipusUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusUbicacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusUbicacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusUbicacio>().GetByIdAsync(request.UpdateTipusUbicacio.Id);

            if (tipusUbicacioDb is not null)
            {
                request.UpdateTipusUbicacio.Adapt(tipusUbicacioDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusUbicacio>().UpdateAsync(tipusUbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusUbicacioDb.Id, "TipusUbicacio actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusUbicacio no existeix!");

        }
    }
}
