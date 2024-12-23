using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Explotacions.Commands
{
    public class UpdateExplotacioCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveExplotacioDTO UpdateExplotacio { get; set; }
    }

    public class UpdateExplotacioCommandHandler : IRequestHandler<UpdateExplotacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExplotacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateExplotacioCommand request, CancellationToken cancellationToken)
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
