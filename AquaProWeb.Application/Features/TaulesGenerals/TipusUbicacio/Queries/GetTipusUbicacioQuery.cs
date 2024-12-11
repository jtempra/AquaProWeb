using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusUbicacio.Queries
{
    public class GetTipusUbicacioQuery : IRequest<ResponseWrapper<List<ReadTipusUbicacioDTO>>>
    {
    }

    public class GetTipusUbicacioQueryHandler : IRequestHandler<GetTipusUbicacioQuery, ResponseWrapper<List<ReadTipusUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusUbicacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadTipusUbicacioDTO>>> Handle(GetTipusUbicacioQuery request, CancellationToken cancellationToken)
        {
            var tipusUbicacioDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetAllAsync();

            if (tipusUbicacioDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadTipusUbicacioDTO>>().Success(tipusUbicacioDb.Adapt<List<ReadTipusUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadTipusUbicacioDTO>>().Failure("No hi han TipusUbicacio!");
        }
    }
}
