using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Commands
{
    public class CreatePoblacioCommand : IRequest<ResponseWrapper<int>>
    {
        public CreatePoblacioDTO CreatePoblacio { get; set; }
    }

    public class CreatePoblacioCommandHandler : IRequestHandler<CreatePoblacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePoblacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreatePoblacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var poblacio = request.CreatePoblacio.Adapt<Poblacio>();

            await _unitOfWork.WriteRepositoryFor<Poblacio>().AddAsync(poblacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(poblacio.Id, "Població creada correctament!");
        }
    }
}
