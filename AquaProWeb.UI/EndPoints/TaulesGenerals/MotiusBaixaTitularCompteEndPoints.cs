namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MotiusBaixaTitularCompteEndPoints
    {
        public const string Add = "api/motiusbaixatitularcompte/add";
        public const string Update = "api/motiusbaixatitularcompte/update";
        public const string Delete = "api/motiusbaixatitularcompte";
        public const string GetAll = "api/motiusbaixatitularcompte/all";

        public static string GetById(int id) => $"api/motiusbaixatitularcompte/{id}";
        public static string GetByText(string text) => $"api/motiusbaixatitularcompte/search/{text}";
    }
}
