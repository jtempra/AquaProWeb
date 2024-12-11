using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Commands
{
    public class UpdateUsContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateUsContracteDTO UpdateUsContracte { get; set; }
    }

    public class UpdateUsContracteCommandHandler : IRequestHandler<UpdateUsContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUsContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateUsContracteCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var UsContracteDb = await _unitOfWork.ReadRepositoryFor<UsContracte>().GetByIdAsync(request.UpdateUsContracte.Id);

            if (UsContracteDb is not null)
            {
                request.UpdateUsContracte.Adapt(UsContracteDb);

                await _unitOfWork.WriteRepositoryFor<Domain.Entities.UsContracte>().UpdateAsync(UsContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(UsContracteDb.Id, "UsContracte actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("UsContracte no existeix!");

        }
    }
}
