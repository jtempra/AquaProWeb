
using AquaProWeb.Common.Responses.Abonats.Ubicacions;
using FluentValidation;

namespace AquaProWeb.UI.Validations.Ubicacions
{
    public class UbicacioValidator : AbstractValidator<ReadUbicacioDTO>
    {
        public UbicacioValidator()
        {

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("El número del punt de subministrament no pot estar en blanc")
                .MaximumLength(12).WithMessage("El número del punt de subministrament no pot superar els 12 caracters");
            RuleFor(c => c.Bloc)
                .MaximumLength(12).WithMessage("El bloc del punt de subministrament no pot superar els 12 caracters");
            RuleFor(c => c.Escala)
                .MaximumLength(12).WithMessage("L'escala del punt de subministrament no pot superar els 12 caracters");
            RuleFor(c => c.Pis)
                .MaximumLength(12).WithMessage("El pis del punt de subministrament no pot superar els 12 caracters");
            RuleFor(c => c.Porta)
                .MaximumLength(12).WithMessage("La porta del punt de subministrament no pot superar els 12 caracters");
            RuleFor(c => c.ResteAdreça)
                .MaximumLength(255).WithMessage("El reste de l'adreça del punt de subministrament no pot superar els 255 caracters");
            RuleFor(c => c.Localitzacio)
                .MaximumLength(255).WithMessage("La localització del punt de subministrament no pot superar els 255 caracters");
            RuleFor(c => c.Observacions)
                .MaximumLength(2000).WithMessage("Les observacions del punt de subministrament no pot superar els 2000 caracters");
            RuleFor(c => c.SituacioComptador)
                .MaximumLength(1000).WithMessage("La situacio del comptador del punt de subministrament no pot superar els 1000 caracters");
            RuleFor(c => c.ReferenciaCatastral)
                .MaximumLength(50).WithMessage("La referencia catastral del punt de subministrament no pot superar els 50 caracters");

            RuleFor(c => c.PoblacioId).NotEqual(0).WithMessage("El població no pot estar buida")
                .NotEmpty().WithMessage("La població no pot estar en blanc");

            RuleFor(c => c.CarrerId).NotEqual(0).WithMessage("El carrer no pot estar buit")
                .NotEmpty().WithMessage("El carrer no pot estar buit");

            RuleFor(c => c.TipusUbicacioId).NotEqual(0).WithMessage("El tipus d'ubicació no pot estar buit")
                .NotEmpty().WithMessage("El tipus d'ubicacio no pot estar buit");

            RuleFor(c => c.ZonaUbicacioId).NotEqual(0).WithMessage("La zona de la ubicació no pot estar buida")
                .NotEmpty().WithMessage("La zona de la ubicació no pot estar buit");

            RuleFor(c => c.RutaLecturaId).NotEqual(0).WithMessage("La ruta de lectura de la ubicació no pot estar buida")
                .NotEmpty().WithMessage("La zona de la ubicació no pot estar buit");

            RuleFor(c => c.OrdreRutaLectura)
                .NotEmpty().WithMessage("L'ordre de la ruta de lectura de la ubicació no pot estar buida");

        }


        // funció de validació
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ReadUbicacioDTO>.CreateWithOptions((ReadUbicacioDTO)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };



    }
}

