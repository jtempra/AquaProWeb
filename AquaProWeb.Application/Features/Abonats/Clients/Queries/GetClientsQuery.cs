using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Queries
{
    public class GetClientsQuery : IRequest<ResponseWrapper<List<ReadClientDTO>>>
    {
    }

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, ResponseWrapper<List<ReadClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadClientDTO>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var ClientsDb = await _unitOfWork.ReadRepositoryFor<Client>().GetAllAsync(p => p.Pais, t => t.TipusClient, t => t.TipusVia);

            if (ClientsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadClientDTO>>().Success(ClientsDb.Adapt<List<ReadClientDTO>>());
            }

            return new ResponseWrapper<List<ReadClientDTO>>().Failure("No hi han Clients!");
        }
    }
}
