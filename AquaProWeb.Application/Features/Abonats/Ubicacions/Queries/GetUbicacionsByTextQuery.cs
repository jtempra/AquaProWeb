using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Queries
{
    public class GetUbicacionsByTextQuery : IRequest<ResponseWrapper<List<ReadUbicacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetUbicacionsByTextQueryHandler : IRequestHandler<GetUbicacionsByTextQuery, ResponseWrapper<List<ReadUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUbicacionsByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadUbicacioDTO>>> Handle(GetUbicacionsByTextQuery request, CancellationToken cancellationToken)
        {
            var UbicacionsDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByTextAsync(request.Text);

            if (UbicacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadUbicacioDTO>>().Success(UbicacionsDb.Adapt<List<ReadUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ReadUbicacioDTO>>().Failure("No s'han trobat Ubicacions!");
        }
    }
}
