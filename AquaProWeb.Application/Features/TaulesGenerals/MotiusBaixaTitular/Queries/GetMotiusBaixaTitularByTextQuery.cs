using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Queries
{
    public class GetMotiusBaixaTitularByTextQuery : IRequest<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetMotiusBaixaTitularByTextQueryHandler : IRequestHandler<GetMotiusBaixaTitularByTextQuery, ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiusBaixaTitularByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>> Handle(GetMotiusBaixaTitularByTextQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaTitularDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaTitular>().GetByTextAsync(request.Text);

            if (motiuBaixaTitularDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>().Success(motiuBaixaTitularDb.Adapt<List<ReadMotiuBaixaTitularDTO>>());
            }

            return new ResponseWrapper<List<ReadMotiuBaixaTitularDTO>>().Failure("No s'han trobat Empresas!");
        }
    }
}
