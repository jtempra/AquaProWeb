namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MotiusBaixaContracteEndPoints
    {
        public const string Add = "api/motiusbaixacontracte/add";
        public const string Update = "api/motiusbaixacontracte/update";
        public const string Delete = "api/motiusbaixacontracte";
        public const string GetAll = "api/motiusbaixacontracte/all";

        public static string GetById(int id) => $"api/motiusbaixacontracte/{id}";
        public static string GetByText(string text) => $"api/motiusbaixacontracte/search/{text}";
    }
}
