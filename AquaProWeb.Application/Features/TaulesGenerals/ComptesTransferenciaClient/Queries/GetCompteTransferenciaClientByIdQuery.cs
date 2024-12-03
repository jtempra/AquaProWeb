using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.ComptesTransferenciaClient;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.ComptesTransferenciaClient.Queries
{
    public class GetCompteTransferenciaClientByIdQuery : IRequest<ResponseWrapper<ReadCompteTransferenciaClientDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCompteTransferenciaClientByIdQueryHandler : IRequestHandler<GetCompteTransferenciaClientByIdQuery, ResponseWrapper<ReadCompteTransferenciaClientDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCompteTransferenciaClientByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadCompteTransferenciaClientDTO>> Handle(GetCompteTransferenciaClientByIdQuery request, CancellationToken cancellationToken)
        {
            var compteTransferenciaClientDb = await _unitOfWork.ReadRepositoryFor<CompteTransferenciaClient>().GetByIdAsync(request.Id);

            if (compteTransferenciaClientDb is not null)
            {
                var CompteTransferenciaClientDTO = compteTransferenciaClientDb.Adapt<ReadCompteTransferenciaClientDTO>();

                return new ResponseWrapper<ReadCompteTransferenciaClientDTO>().Success(CompteTransferenciaClientDTO);
            }

            return new ResponseWrapper<ReadCompteTransferenciaClientDTO>().Failure("El compte de remesa no existeix!");
        }
    }
}
