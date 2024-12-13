using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Queries
{
    public class GetUsosContracteByTextQuery : IRequest<ResponseWrapper<List<ReadUsContracteDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetUsosContracteByTextQueryHandler : IRequestHandler<GetUsosContracteByTextQuery, ResponseWrapper<List<ReadUsContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsosContracteByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadUsContracteDTO>>> Handle(GetUsosContracteByTextQuery request, CancellationToken cancellationToken)
        {
            var UsosContracteDb = await _unitOfWork.ReadRepositoryFor<UsContracte>().GetByTextAsync(request.Text);

            if (UsosContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadUsContracteDTO>>().Success(UsosContracteDb.Adapt<List<ReadUsContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadUsContracteDTO>>().Failure("No s'han trobat UsosContracte!");
        }
    }
}
