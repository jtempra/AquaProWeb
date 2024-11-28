namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusUbicacioEndPoints
    {
        public const string Add = "api/tipusubicacio/add";
        public const string Update = "api/tipusubicacio/update";
        public const string Delete = "api/tipusubicacio";
        public const string GetAll = "api/tipusubicacio/all";

        public static string GetById(int id) => $"api/tipusubicacio/{id}";
        public static string GetByText(string text) => $"api/tipusubicacio/search/{text}";
    }
}
