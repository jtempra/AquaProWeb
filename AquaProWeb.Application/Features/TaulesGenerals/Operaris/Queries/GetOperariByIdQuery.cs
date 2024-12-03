using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Operaris;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Operaris.Queries
{
    public class GetOperariByIdQuery : IRequest<ResponseWrapper<ReadOperariDTO>>
    {
        public int Id { get; set; }
    }

    public class GetOperariByIdQueryHandler : IRequestHandler<GetOperariByIdQuery, ResponseWrapper<ReadOperariDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOperariByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadOperariDTO>> Handle(GetOperariByIdQuery request, CancellationToken cancellationToken)
        {
            var operariDb = await _unitOfWork.ReadRepositoryFor<Operari>().GetByIdAsync(request.Id);

            if (operariDb is not null)
            {
                var OperariDTO = operariDb.Adapt<ReadOperariDTO>();

                return new ResponseWrapper<ReadOperariDTO>().Success(OperariDTO);
            }

            return new ResponseWrapper<ReadOperariDTO>().Failure("Operari no existeix!");
        }
    }
}
