using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusReclamacions;
using AquaProWeb.Common.Wrapper;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.TipusReclamacio.Queries
{
    public class GetTipusReclamacioByIdQuery : IRequest<ResponseWrapper<ReadTipusReclamacioDTO>>
    {
        public int Id { get; set; }
    }

    public class GetTipusReclamacioByIdQueryHandler : IRequestHandler<GetTipusReclamacioByIdQuery, ResponseWrapper<ReadTipusReclamacioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTipusReclamacioByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadTipusReclamacioDTO>> Handle(GetTipusReclamacioByIdQuery request, CancellationToken cancellationToken)
        {
            var tipusReclamacioDb = await _unitOfWork.ReadRepositoryFor<Domain.Entities.TipusReclamacio>().GetByIdAsync(request.Id);

            if (tipusReclamacioDb is not null)
            {
                var TipusReclamacioDTO = tipusReclamacioDb.Adapt<ReadTipusReclamacioDTO>();

                return new ResponseWrapper<ReadTipusReclamacioDTO>().Success(TipusReclamacioDTO);
            }

            return new ResponseWrapper<ReadTipusReclamacioDTO>().Failure("TipusReclamacio no existeix!");
        }
    }
}
