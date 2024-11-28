namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class PaisosEndPoints
    {
        public const string Add = "api/paisos/add";
        public const string Update = "api/paisos/update";
        public const string Delete = "api/paisos";
        public const string GetAll = "api/paisos/all";

        public static string GetById(int id) => $"api/paisos/{id}";
        public static string GetByText(string text) => $"api/paisos/search/{text}";
    }
}
