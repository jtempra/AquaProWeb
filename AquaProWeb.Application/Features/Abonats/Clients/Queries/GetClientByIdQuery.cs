using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Clients;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<ResponseWrapper<ReadClientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ResponseWrapper<ReadClientDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<ReadClientDTO>> Handle(GetClientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var ClientDb = await _unitOfWork.ReadRepositoryFor<Client>().GetByIdAsync(request.Id);

            if (ClientDb is not null)
            {
                var ClientDTO = ClientDb.Adapt<ReadClientDTO>();

                return new ResponseWrapper<ReadClientDTO>().Success(ClientDTO);
            }

            return new ResponseWrapper<ReadClientDTO>().Failure("El Client no existeix!");
        }
    }
}
