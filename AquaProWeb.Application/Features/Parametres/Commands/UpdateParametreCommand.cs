using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Commands
{
    public class UpdateParametreCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateExplotacioDTO UpdateExplotacio { get; set; }
    }

    public class UpdateExplotacioCommandHandler : IRequestHandler<UpdateParametreCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExplotacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateParametreCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var explotacioDb = await _unitOfWork.ReadRepositoryFor<Explotacio>().GetByIdAsync(request.UpdateExplotacio.Id);

            if (explotacioDb is not null)
            {
                request.UpdateExplotacio.Adapt(explotacioDb);

                await _unitOfWork.WriteRepositoryFor<Explotacio>().UpdateAsync(explotacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(explotacioDb.Id, "Explotació actualitzada correctament!");
            }

            return new ResponseWrapper<int>().Failure("La explotació no existeix!");

        }
    }
}
