using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Commands
{
    public class CreateFamiliaConcepteFacturaCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateEmpresaDTO CreateEmpresa { get; set; }
    }

    public class CreateFamiliaConcepteCommandHandler : IRequestHandler<CreateFamiliaConcepteFacturaCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFamiliaConcepteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateFamiliaConcepteFacturaCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var empresa = request.CreateEmpresa.Adapt<Empresa>();

            await _unitOfWork.WriteRepositoryFor<Empresa>().AddAsync(empresa);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(empresa.Id, "Empresa creat correctament!");
        }
    }
}
