namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MotiusBaixaContacteEndPoints
    {
        public const string Add = "api/motiusbaixacontacte/add";
        public const string Update = "api/motiusbaixacontacte/update";
        public const string Delete = "api/motiusbaixacontacte";
        public const string GetAll = "api/motiusbaixacontacte/all";

        public static string GetById(int id) => $"api/motiusbaixacontacte/{id}";
        public static string GetByText(string text) => $"api/motiusbaixacontacte/search/{text}";
    }
}
