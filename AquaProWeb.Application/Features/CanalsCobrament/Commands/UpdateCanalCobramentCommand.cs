using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.CanalsCobrament.Commands
{
    public class UpdateCanalCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateCanalCobramentDTO UpdateCanalCobrament { get; set; }
    }

    public class UpdateCanalCobramentCommandHandler : IRequestHandler<UpdateCanalCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCanalCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateCanalCobramentCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var canalCobramentDb = await _unitOfWork.ReadRepositoryFor<CanalCobrament>().GetByIdAsync(request.UpdateCanalCobrament.Id);

            if (canalCobramentDb is not null)
            {
                request.UpdateCanalCobrament.Adapt(canalCobramentDb);

                await _unitOfWork.WriteRepositoryFor<CanalCobrament>().UpdateAsync(canalCobramentDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(canalCobramentDb.Id, "Canal de cobrament actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El canal de ccobrament no existeix!");

        }
    }
}
