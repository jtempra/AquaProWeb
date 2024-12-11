using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Commands
{
    public class UpdateTipusReclamacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateTipusReclamacioDTO UpdateTipusReclamacio { get; set; }
    }

    public class UpdateTipusReclamacioCommandHandler : IRequestHandler<UpdateTipusReclamacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTipusReclamacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateTipusReclamacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var tipusReclamacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusReclamacio>().GetByIdAsync(request.UpdateTipusReclamacio.Id);

            if (tipusReclamacioDb is not null)
            {
                request.UpdateTipusReclamacio.Adapt(tipusReclamacioDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.TipusReclamacio>().UpdateAsync(tipusReclamacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(tipusReclamacioDb.Id, "TipusReclamacio actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("TipusReclamacio no existeix!");

        }
    }
}
