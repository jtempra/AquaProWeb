using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MotiusBaixaCompte;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MotiusBaixaCompteCompte.Queries
{
    public class GetMotiuBaixaCompteByIdQuery : IRequest<ResponseWrapper<ReadMotiuBaixaCompteDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMotiuBaixaCompteByIdQueryHandler : IRequestHandler<GetMotiuBaixaCompteByIdQuery, ResponseWrapper<ReadMotiuBaixaCompteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMotiuBaixaCompteByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadMotiuBaixaCompteDTO>> Handle(GetMotiuBaixaCompteByIdQuery request, CancellationToken cancellationToken)
        {
            var motiuBaixaCompteDb = await _unitOfWork.ReadRepositoryFor<MotiuBaixaCompte>().GetByIdAsync(request.Id);

            if (motiuBaixaCompteDb is not null)
            {
                var MotiuBaixaCompteDTO = motiuBaixaCompteDb.Adapt<ReadMotiuBaixaCompteDTO>();

                return new ResponseWrapper<ReadMotiuBaixaCompteDTO>().Success(MotiuBaixaCompteDTO);
            }

            return new ResponseWrapper<ReadMotiuBaixaCompteDTO>().Failure("El MotiuBaixa Compte no existeix!");
        }
    }
}
