using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Queries
{
    public class GetMotiusBaixaComptadorQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>>
    {
    }

    public class GetMotiusBaixaComptadorQueryHandler : IRequestHandler<GetMotiusBaixaComptadorQuery, ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaComptadorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>> Handle(GetMotiusBaixaComptadorQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaComptador>().GetAllAsync();

            if (motiuBaixaComptadorDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>().Success(motiuBaixaComptadorDb.Adapt<List<ReadMotiuBaixaComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaComptadorDTO>>().Failure("No hi han Empresas!");
        }
    }
}
