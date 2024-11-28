using AquaProWeb.Common.Responses.Parametres;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class RutaLecturaValidator : AbstractValidator<ReadRutaLecturaDTO>
	{
		public RutaLecturaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadRutaLecturaDTO>.CreateWithOptions((ReadRutaLecturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
