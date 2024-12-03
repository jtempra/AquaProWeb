using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class UpdateEmpresaCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateEmpresaDTO UpdateEmpresa { get; set; }
    }

    public class UpdateEmpresaCommandHandler : IRequestHandler<UpdateEmpresaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmpresaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateEmpresaCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var empresaDb = await _unitOfWork.ReadRepositoryFor<Empresa>().GetByIdAsync(request.UpdateEmpresa.Id);

            if (empresaDb is not null)
            {
                request.UpdateEmpresa.Adapt(empresaDb);

                await _unitOfWork.WriteRepositoryFor<Empresa>().UpdateAsync(empresaDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(empresaDb.Id, "Empresa actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Empresa no existeix!");

        }
    }
}
