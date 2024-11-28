namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MotiusBaixaTitularEndPoints
    {
        public const string Add = "api/motiusbaixatitular/add";
        public const string Update = "api/motiusbaixatitular/update";
        public const string Delete = "api/motiusbaixatitular";
        public const string GetAll = "api/motiusbaixatitular/all";

        public static string GetById(int id) => $"api/motiusbaixatitular/{id}";
        public static string GetByText(string text) => $"api/motiusbaixatitular/search/{text}";
    }
}
