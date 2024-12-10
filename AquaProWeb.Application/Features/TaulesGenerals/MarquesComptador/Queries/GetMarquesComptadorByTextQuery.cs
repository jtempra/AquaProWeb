using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Queries
{

    public class GetMarquesComptadorByTextQuery : IRequest<ResponseWrapper<List<ReadMarcaComptadorDTO>>>
    {
        public string Text { get; set; }
    }

    public class GetMarquesComptadorByTextQueryHandler : IRequestHandler<GetMarquesComptadorByTextQuery, ResponseWrapper<List<ReadMarcaComptadorDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMarquesComptadorByTextQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<List<ReadMarcaComptadorDTO>>> Handle(GetMarquesComptadorByTextQuery request, CancellationToken cancellationToken)
        {
            var familiaContracteDb = await _unitOfWork.ReadRepositoryFor<MarcaComptador>().GetByTextAsync(request.Text);

            if (familiaContracteDb.Count > 0)
            {
                return new ResponseWrapper<List<ReadMarcaComptadorDTO>>().Success(familiaContracteDb.Adapt<List<ReadMarcaComptadorDTO>>());
            }

            return new ResponseWrapper<List<ReadMarcaComptadorDTO>>().Failure("No s'han trobat Empresas!");
        }
    }

}
