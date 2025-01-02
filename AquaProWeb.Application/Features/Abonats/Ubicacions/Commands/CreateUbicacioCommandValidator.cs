using AquaProWeb.Application.Repositories;
using AquaProWeb.Common.Requests.Abonats.PuntsSubministrament;
using AquaProWeb.Domain.Entities;
using FluentValidation;

namespace AquaProWeb.Application.Features.Abonats.Ubicacions.Commands
{
    public class CreateUbicacioCommandValidator : AbstractValidator<SaveUbicacioDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUbicacioCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            // no pot haber dues ubicacions amb la mateixa ruta i el mateix ordre

            RuleFor(u => new { u.RutaLecturaId, u.OrdreRutaLectura }).MustAsync((u, cancellationToken) => ExisteixUbicacioRutaOrdre(u.RutaLecturaId, u.OrdreRutaLectura)).WithMessage("Ja existeix una ubicacio amb la mateixa ruta i ordre");

            // no pot haber dues ubicacions a la mateixa adreça

            RuleFor(u => new { u.PoblacioId, u.CarrerId, u.Numero, u.Bloc, u.Escala, u.Pis, u.Porta }).MustAsync((u, cancellationToken) => ExisteixUbicacioAdressa(u.PoblacioId, u.CarrerId, u.Numero, u.Bloc, u.Escala, u.Pis, u.Porta)).WithMessage("Ja existeix una ubicacio amb la mateixa adreça");
        }

        private async Task<bool> ExisteixUbicacioRutaOrdre(int RutaLecturaId, int OrdreRutaLectura)
        {
            var UbicacionsDb = _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByPredicateAsync(c => c.RutaLecturaId == RutaLecturaId && c.OrdreRutaLectura == OrdreRutaLectura);

            if (UbicacionsDb.Count > 0)
            {
                return true;
            }

            return false;
        }


        private async Task<bool> ExisteixUbicacioAdressa(int PoblacioId, int CarrerId, string Num, string Bloc, string Esc, string Pis, string Pta)
        {
            var UbicacionsDb = _unitOfWork.ReadRepositoryFor<Ubicacio>().GetByPredicateAsync(c => c.PoblacioId == PoblacioId && c.CarrerId == CarrerId && c.Numero == Num && c.Bloc == Bloc && c.Escala == Esc && c.Pis == Pis && c.Porta == Pta);

            if (UbicacionsDb.Count > 0)
            {
                return true;
            }

            return false;
        }
    }


}
