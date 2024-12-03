using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Commands
{
    public class CreateFamiliaContracteCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateEmpresaDTO CreateEmpresa { get; set; }
    }

    public class CreateFamiliaContracteCommandHandler : IRequestHandler<CreateFamiliaContracteCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFamiliaContracteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateFamiliaContracteCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var familiaContracte = request.CreateEmpresa.Adapt<FamiliaContracte>();

            await _unitOfWork.WriteRepositoryFor<FamiliaContracte>().AddAsync(familiaContracte);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(familiaContracte.Id, "Familia Contracte creat correctament!");
        }
    }
}
