using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Carrers.Commands
{
    public class DeleteConcepteCobramentCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCarrerCommandHandler : IRequestHandler<DeleteConcepteCobramentCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarrerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteConcepteCobramentCommand Request, CancellationToken cancellationToken)
        {
            var carrerDb = await _unitOfWork.ReadRepositoryFor<Carrer>().GetByIdAsync(Request.Id);

            if (carrerDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Carrer>().DeleteAsync(carrerDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(carrerDb.Id, "Carrer esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Carrer no trobat!");
        }
    }
}
