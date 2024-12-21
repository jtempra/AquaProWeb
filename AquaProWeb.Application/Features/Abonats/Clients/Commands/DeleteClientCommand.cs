using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Commands
{
    public class DeleteClientCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteClientCommand Request, CancellationToken cancellationToken)
        {
            var ClientDb = await _unitOfWork.ReadRepositoryFor<Client>().GetByIdAsync(Request.Id);

            if (ClientDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<Client>().DeleteAsync(ClientDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(ClientDb.Id, "Client esborrat correctament!");
            }

            return new ResponseWrapper<int>().Failure("Client no trobat!");
        }
    }
}
