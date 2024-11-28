namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusComptadorEndPoints
    {
        public const string Add = "api/tipuscomptador/add";
        public const string Update = "api/tipuscomptador/update";
        public const string Delete = "api/tipuscomptador";
        public const string GetAll = "api/tipuscomptador/all";

        public static string GetById(int id) => $"api/tipuscomptador/{id}";
        public static string GetByText(string text) => $"api/tipuscomptador/search/{text}";
    }
}
