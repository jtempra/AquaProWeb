using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Commands
{
    public class CreateOperariCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveOperariDTO CreateOperari { get; set; }
    }

    public class CreateOperariCommandHandler : IRequestHandler<CreateOperariCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOperariCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateOperariCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var operari = request.CreateOperari.Adapt<Operari>();

            await _unitOfWork.WriteRepositoryFor<Operari>().AddAsync(operari);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(operari.Id, "Operari creat correctament!");
        }
    }
}
