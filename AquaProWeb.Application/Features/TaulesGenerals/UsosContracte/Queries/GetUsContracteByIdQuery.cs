using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Queries
{
    public class GetUsContracteByIdQuery : IRequest<ResponseWrapper<ReadUsContracteDTO>>
    {
        public int Id { get; set; }
    }

    public class GetUsContracteByIdQueryHandler : IRequestHandler<GetUsContracteByIdQuery, ResponseWrapper<ReadUsContracteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsContracteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadUsContracteDTO>> Handle(GetUsContracteByIdQuery request, CancellationToken cancellationToken)
        {
            var UsContracteDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.UsContracte>().GetByIdAsync(request.Id);

            if (UsContracteDb is not null)
            {
                var UsContracteDTO = UsContracteDb.Adapt<ReadUsContracteDTO>();

                return new ResponseWrapper<ReadUsContracteDTO>().Success(UsContracteDTO);
            }

            return new ResponseWrapper<ReadUsContracteDTO>().Failure("UsContracte no existeix!");
        }
    }
}
