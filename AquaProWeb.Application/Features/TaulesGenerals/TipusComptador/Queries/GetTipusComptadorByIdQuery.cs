using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusComptadors;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusComptador.Queries
{
    public class GetTipusComptadorByIdQuery : IRequest<ResponseWrapper<ReadTipusComptadorDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusComptadorByIdQueryHandler : IRequestHandler<GetTipusComptadorByIdQuery, ResponseWrapper<ReadTipusComptadorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusComptadorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusComptadorDTO>> Handle(GetTipusComptadorByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusComptadorDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusComptador>().GetByIdAsync(request.Id);

            if (tipusComptadorDb is not null)
            {
                var TipusComptadorDTO = tipusComptadorDb.Adapt<ReadTipusComptadorDTO>();

                return new ResponseWrapper<ReadTipusComptadorDTO>().Success(TipusComptadorDTO);
            }

            return new ResponseWrapper<ReadTipusComptadorDTO>().Failure("TipusComptador no existeix!");
        }
    }
}
