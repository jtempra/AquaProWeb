using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.CanalsCobrament.Commands
{
    public class CreateCanalCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateCanalCobramentDTO CreateCanalCobrament { get; set; }
    }

    public class CreateCanalCobramentCommandHandler : IRequestHandler<CreateCanalCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCanalCobramentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateCanalCobramentCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var canalCobrament = request.CreateCanalCobrament.Adapt<CanalCobrament>();

            await _unitOfWork.WriteRepositoryFor<CanalCobrament>().AddAsync(canalCobrament);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(canalCobrament.Id, "Canal de cobrament creat correctament!");
        }
    }
}
