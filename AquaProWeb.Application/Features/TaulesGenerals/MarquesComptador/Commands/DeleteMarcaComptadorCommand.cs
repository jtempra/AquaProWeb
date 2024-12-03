using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Wrapper;
using AquaProWeb.Domain.Entities;
using MediatR;

namespace AquaProWeb.Application.Features.TaulesGenerals.MarquesComptador.Commands
{
    public class DeleteMarcaComptadorCommand : IRequest<ResponseWrapper<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMarcaComptadorCommandHandler : IRequestHandler<DeleteMarcaComptadorCommand, ResponseWrapper<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMarcaComptadorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseWrapper<int>> Handle(DeleteMarcaComptadorCommand Request, CancellationToken cancellationToken)
        {
            var marcaComptadorDb = await _unitOfWork.ReadRepositoryFor<MarcaComptador>().GetByIdAsync(Request.Id);

            if (marcaComptadorDb is not null)
            {
                await _unitOfWork.WriteRepositoryFor<MarcaComptador>().DeleteAsync(marcaComptadorDb);

                await _unitOfWork.CommitAsync(cancellationToken);

                return new ResponseWrapper<int>().Success(Request.Id, "Canal de cobrament correctament!");
            }

            return new ResponseWrapper<int>().Failure("Canal de cobrament no trobat!");
        }
    }
}
