using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Commands
{
    public class DeleteUbicacioCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteUbicacioCommandHandler : IRequestHandler<DeleteUbicacioCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUbicacioCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteUbicacioCommand Request, CancellationToken cancellationToken)
        {
            var UbicacioDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByIdAsync(Request.Id);

            if (UbicacioDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Ubicacio>().DeleteAsync(UbicacioDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(UbicacioDb.Id, "Ubicacio esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Ubicacio no trobat!");
        }
    }
}
