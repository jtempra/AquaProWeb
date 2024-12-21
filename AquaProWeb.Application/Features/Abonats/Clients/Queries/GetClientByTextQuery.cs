using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Queries
{
    public class GetClientsByTextQuery : IRequest<ResponseWrapper<List<ReadClientDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetClientsByTextQueryHandler : IRequestHandler<GetClientsByTextQuery, ResponseWrapper<List<ReadClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientsByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadClientDTO>>> Handle(GetClientsByTextQuery request, CancellationToken cancellationToken)
        {
            var ClientsDb = await _unitOfWork.ReadRepositoryFor<Client>().GetByTextAsync(request.Text);

            if (ClientsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadClientDTO>>().Success(ClientsDb.Adapt<List<ReadClientDTO>>());
            }

            return new ResponseWrapper<List<ReadClientDTO>>().Failure("No s'han trobat Clients!");
        }
    }
}
