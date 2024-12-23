using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Commands
{
    public class CreatePaisCommand : IRequest<ResponseWrapper<int>>
    {
        public SavePaisDTO CreatePais { get; set; }
    }

    public class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePaisCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var pais = request.CreatePais.Adapt<Pais>();

            await _unitOfWork.WriteRepositoryFor<Pais>().AddAsync(pais);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(pais.Id, "Pais creat correctament!");
        }
    }
}
