using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Carrers.Queries
{
    public class GetCarrersByIdPoblacioQuery : IRequest<ResponseWrapper<List<ReadCarrerDTO>>>
    {
        public int IdPoblacio { get; set; }
    }

    public class GetCarrersByIdPoblacioQueryHandler : IRequestHandler<GetCarrersByIdPoblacioQuery, ResponseWrapper<List<ReadCarrerDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrersByIdPoblacioQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> Handle(GetCarrersByIdPoblacioQuery request, CancellationToken cancellationToken)
        {
            var carrersDb = _unitOfWork.ReadRepositoryFor<Carrer>().GetByPredicateAsync(c => c.PoblacioId == request.IdPoblacio);

            if (carrersDb is not null)
            {
                var carrersDTO = carrersDb.Adapt<List<ReadCarrerDTO>>();

                return new ResponseWrapper<List<ReadCarrerDTO>>().Success(carrersDTO);
            }

            return new ResponseWrapper<List<ReadCarrerDTO>>().Failure("El carrer no existeix!");
        }
    }

}
