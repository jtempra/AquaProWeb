using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.UsosContracte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.UsosContracte.Queries
{
    public class GetUsosContracteQuery : IRequest<ResponseWrapper<List<ReadUsContracteDTO>>>
    {
    }

    public class GetUsosContracteQueryHandler : IRequestHandler<GetUsosContracteQuery, ResponseWrapper<List<ReadUsContracteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsosContracteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadUsContracteDTO>>> Handle(GetUsosContracteQuery request, CancellationToken cancellationToken)
        {
            var UsosContracteDb = await _unitOfWork.ReadRepositoryFor<UsContracte>().GetAllAsync();

            if (UsosContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadUsContracteDTO>>().Success(UsosContracteDb.Adapt<List<ReadUsContracteDTO>>());
            }

            return new ResponseWrapper<List<ReadUsContracteDTO>>().Failure("No hi han UsosContracte!");
        }
    }
}
