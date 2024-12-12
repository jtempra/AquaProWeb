using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries
{
    public class GetPaisosByTextQuery : IRequest<ResponseWrapper<List<ReadPaisDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetPaisosByTextQueryHandler : IRequestHandler<GetPaisosByTextQuery, ResponseWrapper<List<ReadPaisDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaisosByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadPaisDTO>>> Handle(GetPaisosByTextQuery request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<Pais>().GetByTextAsync(request.Text);

            if (paisDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadPaisDTO>>().Success(paisDb.Adapt<List<ReadPaisDTO>>());
            }

            return new ResponseWrapper<List<ReadPaisDTO>>().Failure("No s'han trobat paisos!");
        }
    }
}
