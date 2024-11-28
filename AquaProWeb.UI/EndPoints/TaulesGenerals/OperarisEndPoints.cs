namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class OperarisEndPoints
    {
        public const string Add = "api/operaris/add";
        public const string Update = "api/operaris/update";
        public const string Delete = "api/operaris";
        public const string GetAll = "api/operaris/all";

        public static string GetById(int id) => $"api/operaris/{id}";
        public static string GetByText(string text) => $"api/operaris/search/{text}";
    }
}
