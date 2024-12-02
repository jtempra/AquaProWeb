using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Commands
{
    public class DeletePoblacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePoblacioCommandHandler : IRequestHandler<DeletePoblacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePoblacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeletePoblacioCommand Request, CancellationToken cancellationToken)
        {
            var poblacioDb = await _unitOfWork.ReadRepositoryFor<Poblacio>().GetByIdAsync(Request.Id);

            if (poblacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Poblacio>().DeleteAsync(poblacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(poblacioDb.Id, "Poblacio esborrada correctament!");
            }

            return new ResponseWrapper<int>().Failure("Població no trobada!");
        }
    }
}
