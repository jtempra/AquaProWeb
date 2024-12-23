using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Queries
{
    public class GetUbicacionsByTextQuery : IRequest<ResponseWrapper<List<ListUbicacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetUbicacionsByTextQueryHandler : IRequestHandler<GetUbicacionsByTextQuery, ResponseWrapper<List<ListUbicacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUbicacionsByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ListUbicacioDTO>>> Handle(GetUbicacionsByTextQuery request, CancellationToken cancellationToken)
        {
            var UbicacionsDb = await _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByTextAsync(request.Text);

            if (UbicacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ListUbicacioDTO>>().Success(UbicacionsDb.Adapt<List<ListUbicacioDTO>>());
            }

            return new ResponseWrapper<List<ListUbicacioDTO>>().Failure("No s'han trobat Ubicacions!");
        }
    }
}
