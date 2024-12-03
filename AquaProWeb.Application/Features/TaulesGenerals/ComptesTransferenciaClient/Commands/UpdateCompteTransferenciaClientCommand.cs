using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Commands
{
    public class UpdateCompteTransferenciaClientCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateCompteTransferenciaClientDTO UpdateCompteTransferenciaClient { get; set; }
    }

    public class UpdateCompteTransferenciaClientCommandHandler : IRequestHandler<UpdateCompteTransferenciaClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompteTransferenciaClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateCompteTransferenciaClientCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var compteTransferenciaClientDb = await _unitOfWork.ReadRepositoryFor<CompteTransferenciaClient>().GetByIdAsync(request.UpdateCompteTransferenciaClient.Id);

            if (compteTransferenciaClientDb is not null)
            {
                request.UpdateCompteTransferenciaClient.Adapt(compteTransferenciaClientDb);

                await _unitOfWork.WriteRepositoryFor<CompteTransferenciaClient>().UpdateAsync(compteTransferenciaClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(compteTransferenciaClientDb.Id, "Compte remesa banc actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El carrer no existeix!");

        }
    }
}
