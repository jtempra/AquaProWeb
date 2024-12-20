using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.PuntsSubministrament;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.PuntsSubministrament.Queries
{
    public class GetPuntsSubministramentQuery : IRequest<ResponseWrapper<List<ReadPuntSubministramentDTO>>>
    {
    }

    public class GetPuntsSubministramentQueryHandler : IRequestHandler<GetPuntsSubministramentQuery, ResponseWrapper<List<ReadPuntSubministramentDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPuntsSubministramentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadPuntSubministramentDTO>>> Handle(GetPuntsSubministramentQuery request, CancellationToken cancellationToken)
        {
            var PuntsSubministramentDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetAllAsync();

            if (PuntsSubministramentDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadPuntSubministramentDTO>>().Success(PuntsSubministramentDb.Adapt<List<ReadPuntSubministramentDTO>>());
            }

            return new ResponseWrapper<List<ReadPuntSubministramentDTO>>().Failure("No hi han Punts de subministrament!");
        }
    }
}
