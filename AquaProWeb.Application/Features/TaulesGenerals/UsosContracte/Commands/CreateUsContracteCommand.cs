using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Commands
{
    public class CreateUsContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateUsContracteDTO CreateUsContracte { get; set; }
    }

    public class CreateUsContracteCommandHandler : IRequestHandler<CreateUsContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUsContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateUsContracteCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var UsContracte = request.CreateUsContracte.Adapt<Domain.Entities.UsContracte>();

            await _unitOfWork.WriteRepositoryFor<Domain.Entities.UsContracte>().AddAsync(UsContracte);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(UsContracte.Id, "UsContracte creat correctament!");
        }
    }
}
