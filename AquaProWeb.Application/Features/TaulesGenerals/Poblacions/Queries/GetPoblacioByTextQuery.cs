using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Poblacions.Queries
{
    public class GetPoblacioByTextQuery : IRequest<ResponseWrapper<List<ReadPoblacioDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetPoblacioByTextQueryHandler : IRequestHandler<GetPoblacioByTextQuery, ResponseWrapper<List<ReadPoblacioDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPoblacioByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadPoblacioDTO>>> Handle(GetPoblacioByTextQuery request, CancellationToken cancellationToken)
        {
            var poblacionsDb = await _unitOfWork.ReadRepositoryFor<Poblacio>().GetByTextAsync(request.Text);

            if (poblacionsDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadPoblacioDTO>>().Success(poblacionsDb.Adapt<List<ReadPoblacioDTO>>());
            }

            return new ResponseWrapper<List<ReadPoblacioDTO>>().Failure("No s'han trobat poblacions!");
        }
    }
}
