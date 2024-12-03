using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaTitular;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaTitular.Queries
{
    public class GetMotiuBaixaTitularByIdQuery : IRequest<ResponseWrapper<ReadMotiuBaixaTitularDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMotiuBaixaTitularByIdQueryHandler : IRequestHandler<GetMotiuBaixaTitularByIdQuery, ResponseWrapper<ReadMotiuBaixaTitularDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiuBaixaTitularByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadMotiuBaixaTitularDTO>> Handle(GetMotiuBaixaTitularByIdQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaTitularDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaTitular>().GetByIdAsync(request.Id);

            if (motiuBaixaTitularDb is not null)
            {
                var MotiuBaixaTitularDTO = motiuBaixaTitularDb.Adapt<ReadMotiuBaixaTitularDTO>();

                return new ResponseWrapper<ReadMotiuBaixaTitularDTO>().Success(MotiuBaixaTitularDTO);
            }

            return new ResponseWrapper<ReadMotiuBaixaTitularDTO>().Failure("El MotiuBaixa Titular no existeix!");
        }
    }
}
