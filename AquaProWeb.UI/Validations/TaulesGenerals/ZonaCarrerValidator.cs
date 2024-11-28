using AquaProWeb.Common.Responses.TaulesGenerals.ZonesCarrers;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesFacturacio;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{

	public class ZonaCarrerValidator : AbstractValidator<ReadZonaCarrerDTO>
	{
		public ZonaCarrerValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadZonaCarrerDTO>.CreateWithOptions((ReadZonaCarrerDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
