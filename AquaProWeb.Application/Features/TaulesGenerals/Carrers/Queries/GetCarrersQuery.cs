using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Carrers.Queries
{
    public class GetConceptesCobramentQuery : IRequest<ResponseWrapper<List<ReadCarrerDTO>>>
    {
    }

    public class GetCarrersQueryHandler : IRequestHandler<GetConceptesCobramentQuery, ResponseWrapper<List<ReadCarrerDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> Handle(GetConceptesCobramentQuery request, CancellationToken cancellationToken)
        {
            var carrersDb = await _unitOfWork.ReadRepositoryFor<Carrer>().GetAllAsync(p => p.Poblacio, z => z.Zona, t => t.TipusVia);

            if (carrersDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCarrerDTO>>().Success(carrersDb.Adapt<List<ReadCarrerDTO>>());
            }

            return new ResponseWrapper<List<ReadCarrerDTO>>().Failure("No hi han carrers!");
        }
    }
}
