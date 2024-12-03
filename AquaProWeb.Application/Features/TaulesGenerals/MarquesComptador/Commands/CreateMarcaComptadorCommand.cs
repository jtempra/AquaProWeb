using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.TaulesGenerals.MarquesComptador;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using Mapster;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Commands
{
    public class CreateMarcaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public CreateMarcaComptadorDTO CreateMarcaComptador { get; set; }
    }

    public class CreateMarcaComptadorCommandHandler : IRequestHandler<CreateMarcaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMarcaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseWrapper<int>> Handle(CreateMarcaComptadorCommand request, CancellationToken cancellationToken)
        {
            // convertim les dades del DTO a les dades de la entitat del domini

            var marcaComptador = request.CreateMarcaComptador.Adapt<MarcaComptador>();

            await _unitOfWork.WriteRepositoryFor<MarcaComptador>().AddAsync(marcaComptador);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseWrapper<int>().Success(marcaComptador.Id, "Canal de cobrament creat correctament!");
        }
    }
}
