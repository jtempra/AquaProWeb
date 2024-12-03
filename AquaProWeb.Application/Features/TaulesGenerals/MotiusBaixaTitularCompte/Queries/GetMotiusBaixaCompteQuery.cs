using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompteCompte.Queries
{
    public class GetMotiusBaixaCompteQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>>
    {
    }

    public class GetMotiusBaixaCompteQueryHandler : IRequestHandler<GetMotiusBaixaCompteQuery, ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaCompteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>> Handle(GetMotiusBaixaCompteQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaCompteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (motiuBaixaCompteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>().Success(motiuBaixaCompteDb.Adapt<List<ReadMotiuBaixaCompteDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaCompteDTO>>().Failure("No hi han Empresas!");
        }
    }
}
