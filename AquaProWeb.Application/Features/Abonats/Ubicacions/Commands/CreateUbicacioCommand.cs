using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Commands
{
    public class CreateUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateUbicacioDTO CreateUbicacio { get; set; }
    }

    public class CreateUbicacioCommandHandler : IRequestHandler<CreateUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateUbicacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var Ubicacio = request.CreateUbicacio.Adapt<Ubicacio>();

            await _unitOfWork.WriteRepositoryFor<Ubicacio>().AddAsync(Ubicacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(Ubicacio.Id, "Ubicacio creat correctament!");
        }
    }
}
