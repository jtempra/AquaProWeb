namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class TipusSuggerimentsEndPoints
    {
		public const string Add = "api/tipussuggeriment/add";
		public const string Update = "api/tipussuggeriment/update";
		public const string Delete = "api/tipussuggeriment";
		public const string GetAll = "api/tipussuggeriment/all";

		public static string GetById(int id) => $"api/tipussuggeriment/{id}";
		public static string GetByText(string text) => $"api/tipussuggeriment/search/{text}";
	}
}
