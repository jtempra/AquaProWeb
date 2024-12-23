using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Commands
{
    public class CreateClientCommand : IRequest<ResponseWrapper<int>>
    {
        public SaveClientDTO CreateClient { get; set; }
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var Client = request.CreateClient.Adapt<Client>();

            await _unitOfWork.WriteRepositoryFor<Client>().AddAsync(Client);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(Client.Id, "Client creat correctament!");
        }
    }
}
