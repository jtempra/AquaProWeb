namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class EmpresesEndPoints
    {
        public const string Add = "api/empreses/add";
        public const string Update = "api/empreses/update";
        public const string Delete = "api/empreses";
        public const string GetAll = "api/empreses/all";

        public static string GetById(int id) => $"api/empreses/{id}";
        public static string GetByText(string text) => $"api/empreses/search/{text}";
    }
}
