using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Queries
{
    public class GetParametreByIdQuery : IRequest<ResponseWrapper<ReadParametreDTO>>
    {
        public int Id { get; set; }
    }

    public class GetParametreByIdQueryHandler : IRequestHandler<GetParametreByIdQuery, ResponseWrapper<ReadParametreDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetParametreByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadParametreDTO>> Handle(GetParametreByIdQuery request, CancellationToken cancellationToken)
        {
            var ParametreDb = await _unitOfWork.ReadRepositoryFor<Parametre>().GetByIdAsync(request.Id);

            if (ParametreDb is not null)
            {
                return new ResponseWrapper<ReadParametreDTO>().Success(ParametreDb.Adapt<ReadParametreDTO>());
            }

            return new ResponseWrapper<ReadParametreDTO>().Failure("La explotació no existeix!");
        }
    }
}
