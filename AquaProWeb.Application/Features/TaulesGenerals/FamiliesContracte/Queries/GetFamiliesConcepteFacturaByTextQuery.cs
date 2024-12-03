using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Queries
{
    public class GetFamiliesContracteByTextQuery : IRequest<ResponseWrapper<List<ReadFamiliaContracteDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetFamiliesContracteByTextQueryHandler : IRequestHandler<GetFamiliesContracteByTextQuery, ResponseWrapper<List<ReadFamiliaContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliesContracteByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadFamiliaContracteDTO>>> Handle(GetFamiliesContracteByTextQuery request, CancellationToken cancellationToken)
        {
            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<FamiliaContracte>().GetByTextAsync(request.Text);

            if (familiaContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadFamiliaContracteDTO>>().Success(familiaContracteDb.Adapt<List<ReadFamiliaContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadFamiliaContracteDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
