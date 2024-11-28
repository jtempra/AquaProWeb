namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MarquesComptadorEndPoints
    {
        public const string Add = "api/marquescomptador/add";
        public const string Update = "api/marquescomptador/update";
        public const string Delete = "api/marquescomptador";
        public const string GetAll = "api/marquescomptador/all";

        public static string GetById(int id) => $"api/marquescomptador/{id}";
        public static string GetByText(string text) => $"api/marquescomptador/search/{text}";
    }
}
