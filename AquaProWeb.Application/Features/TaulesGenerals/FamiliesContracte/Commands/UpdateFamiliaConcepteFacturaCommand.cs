using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Commands
{
    public class UpdateFamiliaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveFamiliaContracteDTO UpdateFamiliaContracte { get; set; }
    }

    public class UpdateFamiliaContracteCommandHandler : IRequestHandler<UpdateFamiliaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFamiliaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateFamiliaContracteCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<FamiliaContracte>().GetByIdAsync(request.UpdateFamiliaContracte.Id);

            if (familiaContracteDb is not null)
            {
                request.UpdateFamiliaContracte.Adapt(familiaContracteDb);

                await _unitOfWork.WriteRepositoryFor<FamiliaContracte>().UpdateAsync(familiaContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(familiaContracteDb.Id, "Empresa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Empresa no existeix!");

        }
    }
}
