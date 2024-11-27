using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusVies;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TipusVies.Commands
{
    public class UpdateTipusViaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusViaDTO UpdateTipusVia { get; set; }
    }

    public class UpdateTipusViaCommandHandler : IRequestHandler<UpdateTipusViaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusViaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusViaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusViaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusVia>().GetByIdAsync(request.UpdateTipusVia.Id);

            if (tipusViaDb is not null)
            {
                request.UpdateTipusVia.Adapt(tipusViaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusVia>().UpdateAsync(tipusViaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusViaDb.Id, "Tipus via actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La explotació no existeix!");

        }
    }
}
