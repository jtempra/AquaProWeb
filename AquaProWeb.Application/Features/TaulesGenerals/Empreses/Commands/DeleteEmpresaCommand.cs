using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class DeleteEmpresaCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteEmpresaCommandHandler : IRequestHandler<DeleteEmpresaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmpresaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteEmpresaCommand Request, CancellationToken cancellationToken)
        {
            var empresaDb = await _unitOfWork.ReadRepositoryFor<Empresa>().GetByIdAsync(Request.Id);

            if (empresaDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Empresa>().DeleteAsync(empresaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(empresaDb.Id, "Empresa esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Empresa no trobat!");
        }
    }
}
