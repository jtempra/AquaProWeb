using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Carrers.Commands
{
    public class CreateCarrerCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateCarrerDTO CreateCarrer { get; set; }
    }

    public class CreateCarrerCommandHandler : IRequestHandler<CreateCarrerCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateCarrerCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var carrer = request.CreateCarrer.Adapt<Carrer>();

            await _unitOfWork.WriteRepositoryFor<Carrer>().AddAsync(carrer);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(carrer.Id, "Carrer creat correctament!");
        }
    }
}
