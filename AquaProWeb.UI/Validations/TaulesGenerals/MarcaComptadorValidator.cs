using AquaProWeb.Common.Responses.TaulesGenerals.FamiliesContracte;
using AquaProWeb.Common.Responses.TaulesGenerals.MarquesComptador;
using FluentValidation;

namespace AquaProWeb.UI.Validations.TaulesGenerals
{
	public class MarcaComptadorValidator : AbstractValidator<ReadMarcaComptadorDTO>
	{
		public MarcaComptadorValidator()
		{

		}

		// funció de validació
		public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
		{
			var result = await ValidateAsync(ValidationContext<ReadMarcaComptadorDTO>.CreateWithOptions((ReadMarcaComptadorDTO)model, x => x.IncludeProperties(propertyName)));
			if (result.IsValid)
				return Array.Empty<string>();
			return result.Errors.Select(e => e.ErrorMessage);
		};

	}
}
