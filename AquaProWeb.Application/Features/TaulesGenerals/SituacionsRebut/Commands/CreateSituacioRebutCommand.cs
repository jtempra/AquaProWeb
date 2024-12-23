using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.SituacioRebut;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.SituacionsRebut.Commands
{
    public class CreateSituacioRebutCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveSituacioRebutDTO CreateSituacioRebut { get; set; }
    }

    public class CreateSituacioRebutCommandHandler : IRequestHandler<CreateSituacioRebutCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSituacioRebutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateSituacioRebutCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var situacioRebut = request.CreateSituacioRebut.Adapt<SituacioRebut>();

            await _unitOfWork.WriteRepositoryFor<SituacioRebut>().AddAsync(situacioRebut);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(situacioRebut.Id, "SituacioRebut creat correctament!");
        }
    }
}
