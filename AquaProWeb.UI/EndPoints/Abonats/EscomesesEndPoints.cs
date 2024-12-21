namespace AquaProWeb.UI.EndPoints.Abonats
{
    public static class EscomesesEndPoints
    {
        public const string Add = "api/escomeses/add";
        public const string Update = "api/escomeses/update";
        public const string Delete = "api/escomeses";
        public const string GetAll = "api/escomeses/all";

        public static string GetById(int id) => $"api/escomeses/{id}";
        public static string GetByText(string text) => $"api/escomeses/search/{text}";
    }
}
