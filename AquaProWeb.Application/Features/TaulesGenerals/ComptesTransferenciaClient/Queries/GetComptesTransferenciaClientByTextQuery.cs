using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Queries
{
    public class GetComptesTransferenciaClientByTextQuery : IRequest<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetCompteTransferenciaClientByTextQueryHandler : IRequestHandler<GetComptesTransferenciaClientByTextQuery, ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteTransferenciaClientByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>> Handle(GetComptesTransferenciaClientByTextQuery request, CancellationToken cancellationToken)
        {
            var compteTransferenciaClientsDb = await _unitOfWork.ReadRepositoryFor<CompteTransferenciaClient>().GetByTextAsync(request.Text);

            if (compteTransferenciaClientsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>().Success(compteTransferenciaClientsDb.Adapt<List<ReadCompteTransferenciaClientDTO>>());
            }

            return new ResponseWrapper<List<ReadCompteTransferenciaClientDTO>>().Failure("No s'han trobat comptes de remesa!");
        }
    }
}
