using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Queries
{
    public class GetFamiliesContracteQuery : IRequest<ResponseWrapper<List<ReadFamiliaContracteDTO>>>
    {
    }

    public class GetFamiliesContracteQueryHandler : IRequestHandler<GetFamiliesContracteQuery, ResponseWrapper<List<ReadFamiliaContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliesContracteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> Handle(GetFamiliesContracteQuery request, CancellationToken cancellationToken)
        {
            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<FamiliaContracte>().GetAllAsync();

            if (familiaContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadFamiliaContracteDTO>>().Success(familiaContracteDb.Adapt<List<ReadFamiliaContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadFamiliaContracteDTO>>().Failure("No hi han Empresas!");
        }
    }
}
