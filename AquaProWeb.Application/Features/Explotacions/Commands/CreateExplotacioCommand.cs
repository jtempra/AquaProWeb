using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Explotacions.Commands
{
    public class CreateExplotacioCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateExplotacioDTO CreateExplotacio { get; set; }
    }

    public class CreateExplotacioCommandHandler : IRequestHandler<CreateExplotacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateExplotacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateExplotacioCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var explotacio = request.CreateExplotacio.Adapt<Explotacio>();

            await _unitOfWork.WriteRepositoryFor<Explotacio>().AddAsync(explotacio);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(explotacio.Id, "Explotacio creat correctament!");
        }
    }
}
