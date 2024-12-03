using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Queries
{
    public class GetComptesTransferenciaClientQuery : IRequest<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>>
    {
    }

    public class GetCompteTransferenciaClientsQueryHandler : IRequestHandler<GetComptesTransferenciaClientQuery, ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteTransferenciaClientsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> Handle(GetComptesTransferenciaClientQuery request, CancellationToken cancellationToken)
        {
            var compteTransferenciaClientsDb = await _unitOfWork.ReadRepositoryFor<CompteTransferenciaClient>().GetAllAsync();

            if (compteTransferenciaClientsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>().Success(compteTransferenciaClientsDb.Adapt<List<ReadCompteTransferenciaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>().Failure("No hi han comptes de remesa!");
        }
    }
}
