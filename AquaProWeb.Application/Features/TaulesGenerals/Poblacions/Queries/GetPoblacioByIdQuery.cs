using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Queries
{
    public class GetPoblacioByIdQuery : IRequest<ResponseWrapper<ReadPoblacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetPoblacioByIdQueryHandler : IRequestHandler<GetPoblacioByIdQuery, ResponseWrapper<ReadPoblacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPoblacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadPoblacioDTO>> Handle(GetPoblacioByIdQuery request, CancellationToken cancellationToken)
        {
            var poblacioDb = await _unitOfWork.ReadRepositoryFor<Poblacio>().GetByIdAsync(request.Id);

            if (poblacioDb is not null)
            {
                return new ResponseWrapper<ReadPoblacioDTO>().Success(poblacioDb.Adapt<ReadPoblacioDTO>());
            }

            return new ResponseWrapper<ReadPoblacioDTO>().Failure("La poblacio no existeix!");
        }
    }
}
