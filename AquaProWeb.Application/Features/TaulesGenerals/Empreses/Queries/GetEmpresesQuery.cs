using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Queries
{
    public class GetEmpresesQuery : IRequest<ResponseWrapper<List<ReadEmpresaDTO>>>
    {
    }

    public class GetEmpresesQueryHandler : IRequestHandler<GetEmpresesQuery, ResponseWrapper<List<ReadEmpresaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmpresesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadEmpresaDTO>>> Handle(GetEmpresesQuery request, CancellationToken cancellationToken)
        {
            var empresasDb = await _unitOfWork.ReadRepositoryFor<Empresa>().GetAllAsync();

            if (empresasDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadEmpresaDTO>>().Success(empresasDb.Adapt<List<ReadEmpresaDTO>>());
            }

            return new ResponseWrapper<List<ReadEmpresaDTO>>().Failure("No hi han Empresas!");
        }
    }
}
