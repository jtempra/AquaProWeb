using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Queries
{
    public class GetMotiusBaixaTitularQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>>
    {
    }

    public class GetMotiusBaixaTitularQueryHandler : IRequestHandler<GetMotiusBaixaTitularQuery, ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaTitularQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> Handle(GetMotiusBaixaTitularQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaTitularDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaTitular>().GetAllAsync();

            if (motiuBaixaTitularDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>().Success(motiuBaixaTitularDb.Adapt<List<ReadMotiuBaixaTitularDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>().Failure("No hi han Empresas!");
        }
    }
}
