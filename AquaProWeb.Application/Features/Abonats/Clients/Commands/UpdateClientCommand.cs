using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Commands
{
    public class UpdateClientCommand : IRequest<ResponseWrapper<int>>
    {
        public UpdateClientDTO UpdateClient { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            // llegim la eentitat de la base de dades

            var ClientDb = await _unitOfWork.ReadRepositoryFor<Client>().GetByIdAsync(request.UpdateClient.Id);

            if (ClientDb is not null)
            {
                request.UpdateClient.Adapt(ClientDb);

                await _unitOfWork.WriteRepositoryFor<Client>().UpdateAsync(ClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(ClientDb.Id, "Client actualitzat correctament!");
            }

            return new ResponseWrapper<int>().Failure("El Client no existeix!");

        }
    }
}
