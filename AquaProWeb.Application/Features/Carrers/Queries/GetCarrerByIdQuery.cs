using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Carrers.Queries
{
    public class GetCarrerByIdQuery : IRequest<ResponseWrapper<ReadCarrerDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCarrerByIdQueryHandler : IRequestHandler<GetCarrerByIdQuery, ResponseWrapper<ReadCarrerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadCarrerDTO>> Handle(GetCarrerByIdQuery request, CancellationToken cancellationToken)
        {
            var carrerDb = await _unitOfWork.ReadRepositoryFor<Carrer>().GetByIdAsync(request.Id, p => p.Poblacio, z => z.Zona, t => t.TipusVia);

            if (carrerDb is not null)
            {
                var carrerDTO = carrerDb.Adapt<ReadCarrerDTO>();

                return new ResponseWrapper<ReadCarrerDTO>().Success(carrerDTO);
            }

            return new ResponseWrapper<ReadCarrerDTO>().Failure("El carrer no existeix!");
        }
    }
}
