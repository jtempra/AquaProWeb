using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Commands
{
    public class DeleteFamiliaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteFamiliaContracteCommandHandler : IRequestHandler<DeleteFamiliaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFamiliaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteFamiliaContracteCommand Request, CancellationToken cancellationToken)
        {
            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<FamiliaContracte>().GetByIdAsync(Request.Id);

            if (familiaContracteDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<FamiliaContracte>().DeleteAsync(familiaContracteDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(familiaContracteDb.Id, "Empresa esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Empresa no trobat!");
        }
    }
}
