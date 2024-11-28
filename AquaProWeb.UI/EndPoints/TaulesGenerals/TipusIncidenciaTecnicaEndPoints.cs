namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusIncidenciaTecnicaEndPoints
    {
        public const string Add = "api/tipusincidenciatecnica/add";
        public const string Update = "api/tipusincidenciatecnica/update";
        public const string Delete = "api/tipusincidenciatecnica";
        public const string GetAll = "api/tipusincidenciatecnica/all";

        public static string GetById(int id) => $"api/tipusincidenciatecnica/{id}";
        public static string GetByText(string text) => $"api/tipusincidenciatecnica/search/{text}";
    }
}
