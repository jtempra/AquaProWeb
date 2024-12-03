using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Paisos.Queries
{
    public class GetPaisByIdQuery : IRequest<ResponseWrapper<ReadPaisDTO>>
    {
        public int Id { get; set; }
    }

    public class GetPaisByIdQueryHandler : IRequestHandler<GetPaisByIdQuery, ResponseWrapper<ReadPaisDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPaisByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadPaisDTO>> Handle(GetPaisByIdQuery request, CancellationToken cancellationToken)
        {
            var paisDb = await _unitOfWork.ReadRepositoryFor<Pais>().GetByIdAsync(request.Id);

            if (paisDb is not null)
            {
                var PaisDTO = paisDb.Adapt<ReadPaisDTO>();

                return new ResponseWrapper<ReadPaisDTO>().Success(PaisDTO);
            }

            return new ResponseWrapper<ReadPaisDTO>().Failure("Pais no existeix!");
        }
    }
}
