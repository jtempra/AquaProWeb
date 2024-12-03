using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Queries
{
    public class GetMarcaComptadorByIdQuery : IRequest<ResponseWrapper<ReadMarcaComptadorDTO>>
    {
        public int Id { get; set; }
    }

    public class GetMarcaComptadorByIdQueryHandler : IRequestHandler<GetMarcaComptadorByIdQuery, ResponseWrapper<ReadMarcaComptadorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMarcaComptadorByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<ReadMarcaComptadorDTO>> Handle(GetMarcaComptadorByIdQuery request, CancellationToken cancellationToken)
        {
            var marcaComptadorDb = await _unitOfWork.ReadRepositoryFor<MarcaComptador>().GetByIdAsync(request.Id);

            if (marcaComptadorDb is not null)
            {
                return new ResponseWrapper<ReadMarcaComptadorDTO>().Success(marcaComptadorDb.Adapt<ReadMarcaComptadorDTO>());
            }

            return new ResponseWrapper<ReadMarcaComptadorDTO>().Failure("El canal de cobrament no existeix!");
        }
    }
}
