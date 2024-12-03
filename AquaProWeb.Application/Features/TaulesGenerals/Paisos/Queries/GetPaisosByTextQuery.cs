using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries
{
    public class GetPaisosByTextQuery : IRequest<ResponseWrapper<List<ReadOperariDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetPaisosByTextQueryHandler : IRequestHandler<GetPaisosByTextQuery, ResponseWrapper<List<ReadOperariDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaisosByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadOperariDTO>>> Handle(GetPaisosByTextQuery request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByTextAsync(request.Text);

            if (paisDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadOperariDTO>>().Success(paisDb.Adapt<List<ReadOperariDTO>>());
            }

            return new ResponseWrapper<List<ReadOperariDTO>>().Failure("No s'han trobat paisos!");
        }
    }
}
