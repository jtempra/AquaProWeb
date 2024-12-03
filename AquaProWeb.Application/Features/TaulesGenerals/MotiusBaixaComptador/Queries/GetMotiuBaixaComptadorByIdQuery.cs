using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaComptador.Queries
{
    public class GetMotiuBaixaComptadorByIdQuery : IRequest<ResponseWrapper<ReadMotiuBaixaComptadorDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMotiuBaixaComptadorByIdQueryHandler : IRequestHandler<GetMotiuBaixaComptadorByIdQuery, ResponseWrapper<ReadMotiuBaixaComptadorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiuBaixaComptadorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadMotiuBaixaComptadorDTO>> Handle(GetMotiuBaixaComptadorByIdQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaComptadorDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaComptador>().GetByIdAsync(request.Id);

            if (motiuBaixaComptadorDb is not null)
            {
                var MotiuBaixaComptadorDTO = motiuBaixaComptadorDb.Adapt<ReadMotiuBaixaComptadorDTO>();

                return new ResponseWrapper<ReadMotiuBaixaComptadorDTO>().Success(MotiuBaixaComptadorDTO);
            }

            return new ResponseWrapper<ReadMotiuBaixaComptadorDTO>().Failure("El MotiuBaixa Comptador no existeix!");
        }
    }
}
