namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusIncidenciaClientEndPoints
    {
        public const string Add = "api/tipusincidenciaclient/add";
        public const string Update = "api/tipusincidenciaclient/update";
        public const string Delete = "api/tipusincidenciaclient";
        public const string GetAll = "api/tipusincidenciaclient/all";

        public static string GetById(int id) => $"api/tipusincidenciaclient/{id}";
        public static string GetByText(string text) => $"api/tipusincidenciaclient/search/{text}";
    }
}
