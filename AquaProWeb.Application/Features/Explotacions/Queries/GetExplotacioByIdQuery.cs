using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Explotacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Explotacions.Queries
{
    public class GetCanalCobramentByIdQuery : IRequest<ResponseWrapper<ReadExplotacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetExplotacioByIdQueryHandler : IRequestHandler<GetCanalCobramentByIdQuery, ResponseWrapper<ReadExplotacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExplotacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadExplotacioDTO>> Handle(GetCanalCobramentByIdQuery request, CancellationToken cancellationToken)
        {
            var explotacioDb = await _unitOfWork.ReadRepositoryFor<Explotacio>().GetByIdAsync(request.Id);

            if (explotacioDb is not null)
            {
                return new ResponseWrapper<ReadExplotacioDTO>().Success(explotacioDb.Adapt<ReadExplotacioDTO>());
            }

            return new ResponseWrapper<ReadExplotacioDTO>().Failure("La explotació no existeix!");
        }
    }
}
