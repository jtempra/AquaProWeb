using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Parametres.Queries
{
    public class GetParametresByTextQuery : IRequest<ResponseWrapper<List<ReadParametreDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetParametresByTextQueryHandler : IRequestHandler<GetParametresByTextQuery, ResponseWrapper<List<ReadParametreDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetParametresByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadParametreDTO>>> Handle(GetParametresByTextQuery request, CancellationToken cancellationToken)
        {
            var ParametresDb = await _unitOfWork.ReadRepositoryFor<Parametre>().GetByTextAsync(request.Text);

            if (ParametresDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadParametreDTO>>().Success(ParametresDb.Adapt<List<ReadParametreDTO>>());
            }

            return new ResponseWrapper<List<ReadParametreDTO>>().Failure("No s'han trobat Parametres!");
        }
    }
}
