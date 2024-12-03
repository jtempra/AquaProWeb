using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Empreses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Empreses.Queries
{
    public class GetEmpresaByIdQuery : IRequest<ResponseWrapper<ReadEmpresaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetEmpresaByIdQueryHandler : IRequestHandler<GetEmpresaByIdQuery, ResponseWrapper<ReadEmpresaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmpresaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadEmpresaDTO>> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
        {
            var empresaDb = await _unitOfWork.ReadRepositoryFor<Empresa>().GetByIdAsync(request.Id);

            if (empresaDb is not null)
            {
                var EmpresaDTO = empresaDb.Adapt<ReadEmpresaDTO>();

                return new ResponseWrapper<ReadEmpresaDTO>().Success(EmpresaDTO);
            }

            return new ResponseWrapper<ReadEmpresaDTO>().Failure("El Empresa no existeix!");
        }
    }
}
