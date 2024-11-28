using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.SeriesFactura;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class SerieFacturaValidator : AbstractValidator<ReadSerieFacturaDTO>
	{
		public SerieFacturaValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadSerieFacturaDTO>.CreateWithOptions((ReadSerieFacturaDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
