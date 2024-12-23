using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Commands
{
    public class CreateParametreCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveParametreDTO CreateParametre { get; set; }
    }

    public class CreateParametreCommandHandler : IRequestHandler<CreateParametreCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateParametreCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateParametreCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var parametre = request.CreateParametre.Adapt<Parametre>();

            await _unitOfWork.WriteRepositoryFor<Parametre>().AddAsync(parametre);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(parametre.Id, "Parametre creat correctament!");
        }
    }
}
