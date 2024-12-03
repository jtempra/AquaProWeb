using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Queries
{
    public class GetMarquesComptadorQuery : IRequest<ResponseWrapper<List<ReadMarcaComptadorDTO>>>
    {
    }

    public class GetMarquesComptadorQueryHandler : IRequestHandler<GetMarquesComptadorQuery, ResponseWrapper<List<ReadMarcaComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMarquesComptadorQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> Handle(GetMarquesComptadorQuery request, CancellationToken cancellationToken)
        {
            var canalsCobramentDb = await _unitOfWork.ReadRepositoryFor<MarcaComptador>().GetAllAsync();

            if (canalsCobramentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMarcaComptadorDTO>>().Success(canalsCobramentDb.Adapt<List<ReadMarcaComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadMarcaComptadorDTO>>().Failure("No hi han canals de cobrament!");
        }
    }
}
