namespace AquaProWeb.UI.EndPoints.Abonats
{
    public static class ClientsEndPoints
    {
        public const string Add = "api/clients/add";
        public const string Update = "api/clients/update";
        public const string Delete = "api/clients";
        public const string GetAll = "api/clients/all";

        public static string GetById(int id) => $"api/clients/{id}";
        public static string GetByText(string text) => $"api/clients/search/{text}";
    }
}
