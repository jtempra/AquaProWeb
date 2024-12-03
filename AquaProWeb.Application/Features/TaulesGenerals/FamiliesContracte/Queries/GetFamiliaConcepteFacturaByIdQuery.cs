using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.FamiliesContracte.Queries
{
    public class GetFamiliaContracteByIdQuery : IRequest<ResponseWrapper<ReadFamiliaContracteDTO>>
    {
        public int Id { get; set; }
    }

    public class GetFamiliaContracteByIdQueryHandler : IRequestHandler<GetFamiliaContracteByIdQuery, ResponseWrapper<ReadFamiliaContracteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFamiliaContracteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadFamiliaContracteDTO>> Handle(GetFamiliaContracteByIdQuery request, CancellationToken cancellationToken)
        {
            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<FamiliaContracte>().GetByIdAsync(request.Id);

            if (familiaContracteDb is not null)
            {
                var FamiliaContracteDTO = familiaContracteDb.Adapt<ReadFamiliaContracteDTO>();

                return new ResponseWrapper<ReadFamiliaContracteDTO>().Success(FamiliaContracteDTO);
            }

            return new ResponseWrapper<ReadFamiliaContracteDTO>().Failure("El FamiliaContracte no existeix!");
        }
    }
}
