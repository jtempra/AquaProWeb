using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaContacte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaContacte.Queries
{
    public class GetMotiusBaixaContacteQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>>
    {
    }

    public class GetMotiusBaixaContacteQueryHandler : IRequestHandler<GetMotiusBaixaContacteQuery, ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaContacteQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>> Handle(GetMotiusBaixaContacteQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaContacteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaContacte>().GetAllAsync();

            if (motiuBaixaContacteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>().Success(motiuBaixaContacteDb.Adapt<List<ReadMotiuBaixaContacteDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaContacteDTO>>().Failure("No hi han Empresas!");
        }
    }
}
