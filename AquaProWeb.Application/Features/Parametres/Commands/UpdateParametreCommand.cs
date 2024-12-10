using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Commands
{
    public class UpdateParametreCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateParametreDTO UpdateParametre { get; set; }
    }

    public class UpdateParametreCommandHandler : IRequestHandler<UpdateParametreCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateParametreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateParametreCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var ParametreDb = await _unitOfWork.ReadRepositoryFor<Parametre>().GetByIdAsync(request.UpdateParametre.Id);

            if (ParametreDb is not null)
            {
                request.UpdateParametre.Adapt(ParametreDb);

                await _unitOfWork.WriteRepositoryFor<Parametre>().UpdateAsync(ParametreDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(ParametreDb.Id, "Explotació actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La explotació no existeix!");

        }
    }
}
