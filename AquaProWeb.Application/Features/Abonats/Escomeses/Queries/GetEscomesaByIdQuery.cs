using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.Abonats.Escomeses.Queries
{
    public class GetEscomesaByIdQuery : IRequest<ResponseWrapper<ReadEscomesaDTO>>
    {
        public int Id { get; set; }
    }

    public class GetEscomesaByIdQueryHandler : IRequestHandler<GetEscomesaByIdQuery, ResponseWrapper<ReadEscomesaDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEscomesaByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadEscomesaDTO>> Handle(GetEscomesaByIdQuery request, CancellationToken cancellationToken)
        {
            var EscomesaDb = await _unitOfWork.ReadRepositoryFor<Escomesa>().GetByIdAsync(request.Id);

            if (EscomesaDb is not null)
            {
                var EscomesaDTO = EscomesaDb.Adapt<ReadEscomesaDTO>();

                return new ResponseWrapper<ReadEscomesaDTO>().Success(EscomesaDTO);
            }

            return new ResponseWrapper<ReadEscomesaDTO>().Failure("El Escomesa no existeix!");
        }
    }
}
