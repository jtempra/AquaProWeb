using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Queries
{
    public class GetEmpresesByTextQuery : IRequest<ResponseWrapper<List<ReadEmpresaDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetEmpresesByTextQueryHandler : IRequestHandler<GetEmpresesByTextQuery, ResponseWrapper<List<ReadEmpresaDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmpresesByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadEmpresaDTO>>> Handle(GetEmpresesByTextQuery request, CancellationToken cancellationToken)
        {
            var empresaDb = await _unitOfWork.ReadRepositoryFor<Empresa>().GetByTextAsync(request.Text);

            if (empresaDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadEmpresaDTO>>().Success(empresaDb.Adapt<List<ReadEmpresaDTO>>());
            }

            return new ResponseWrapper<List<ReadEmpresaDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
