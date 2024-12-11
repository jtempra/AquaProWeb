using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusQueixes;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusQueixa.Commands
{
    public class UpdateTipusQueixaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusQueixaDTO UpdateTipusQueixa { get; set; }
    }

    public class UpdateTipusQueixaCommandHandler : IRequestHandler<UpdateTipusQueixaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusQueixaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusQueixaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusQueixaDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusQueixa>().GetByIdAsync(request.UpdateTipusQueixa.Id);

            if (tipusQueixaDb is not null)
            {
                request.UpdateTipusQueixa.Adapt(tipusQueixaDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusQueixa>().UpdateAsync(tipusQueixaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusQueixaDb.Id, "TipusQueixa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusQueixa no existeix!");

        }
    }
}
