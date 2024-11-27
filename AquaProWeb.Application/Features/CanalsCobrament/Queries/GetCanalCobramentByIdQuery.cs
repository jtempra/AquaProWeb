using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.CanalsCobrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.CanalsCobrament.Queries
{
    public class GetCanalCobramentByIdQuery : IRequest<ResponseWrapper<ReadCanalCobramentDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCanalCobramentByIdQueryHandler : IRequestHandler<GetCanalCobramentByIdQuery, ResponseWrapper<ReadCanalCobramentDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCanalCobramentByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadCanalCobramentDTO>> Handle(GetCanalCobramentByIdQuery request, CancellationToken cancellationToken)
        {
            var canalCobramentDb = await _unitOfWork.ReadRepositoryFor<Explotacio>().GetByIdAsync(request.Id);

            if (canalCobramentDb is not null)
            {
                return new ResponseWrapper<ReadCanalCobramentDTO>().Success(canalCobramentDb.Adapt<ReadCanalCobramentDTO>());
            }

            return new ResponseWrapper<ReadCanalCobramentDTO>().Failure("El canal de cobrament no existeix!");
        }
    }
}
