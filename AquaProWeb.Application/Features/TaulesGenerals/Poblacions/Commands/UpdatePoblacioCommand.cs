using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Commands
{
    public class UpdatePoblacioCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdatePoblacioDTO UpdatePoblacio { get; set; }
    }

    public class UpdatePoblacioCommandHandler : IRequestHandler<UpdatePoblacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePoblacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdatePoblacioCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var poblacioDb = await _unitOfWork.ReadRepositoryFor<Poblacio>().GetByIdAsync(request.UpdatePoblacio.Id);

            if (poblacioDb is not null)
            {
                request.UpdatePoblacio.Adapt(poblacioDb);

                await _unitOfWork.WriteRepositoryFor<Poblacio>().UpdateAsync(poblacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(poblacioDb.Id, "Poblacio actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La Poblacio no existeix!");

        }
    }
}
