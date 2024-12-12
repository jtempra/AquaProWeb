using AquaProWeb.Application.Repositories;

using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Queries
{
    public class GetOperarisByTextQuery : IRequest<ResponseWrapper<List<ReadOperariDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetOperarisByTextQueryHandler : IRequestHandler<GetOperarisByTextQuery, ResponseWrapper<List<ReadOperariDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOperarisByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadOperariDTO>>> Handle(GetOperarisByTextQuery request, CancellationToken cancellationToken)
        {
            var operariDb = await _unitOfWork.ReadRepositoryFor<Operari>().GetByTextAsync(request.Text);

            if (operariDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadOperariDTO>>().Success(operariDb.Adapt<List<ReadOperariDTO>>());
            }

            return new ResponseWrapper<List<ReadOperariDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
