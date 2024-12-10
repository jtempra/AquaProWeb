using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.Carrers.Queries
{
    public class GetCarrersByTextQuery : IRequest<ResponseWrapper<List<ReadCarrerDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetCarrerByTextQueryHandler : IRequestHandler<GetCarrersByTextQuery, ResponseWrapper<List<ReadCarrerDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarrerByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadCarrerDTO>>> Handle(GetCarrersByTextQuery request, CancellationToken cancellationToken)
        {
            var carrersDb = await _unitOfWork.ReadRepositoryFor<Carrer>().GetByTextAsync(request.Text);

            if (carrersDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadCarrerDTO>>().Success(carrersDb.Adapt<List<ReadCarrerDTO>>());
            }

            return new ResponseWrapper<List<ReadCarrerDTO>>().Failure("No s'han trobat carrers!");
        }
    }
}
