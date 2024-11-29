namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class TipusQueixesEndPoints
    {
		public const string Add = "api/tipusqueixa/add";
		public const string Update = "api/tipusqueixa/update";
		public const string Delete = "api/tipusqueixa";
		public const string GetAll = "api/tipusqueixa/all";

		public static string GetById(int id) => $"api/tipusqueixa/{id}";
		public static string GetByText(string text) => $"api/tipusqueixa/search/{text}";
	}
}
