namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class TipusOrdreTreballEndPoints
    {
		public const string Add = "api/tipusot/add";
		public const string Update = "api/tipusot/update";
		public const string Delete = "api/tipusot";
		public const string GetAll = "api/tipusot/all";

		public static string GetById(int id) => $"api/tipusot/{id}";
		public static string GetByText(string text) => $"api/tipusot/search/{text}";
	}
}
