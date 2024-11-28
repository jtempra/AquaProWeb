namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class MotiusBaixaComptadorEndPoints
    {
        public const string Add = "api/motiusbaixacomptador/add";
        public const string Update = "api/motiusbaixacomptador/update";
        public const string Delete = "api/motiusbaixacomptador";
        public const string GetAll = "api/motiusbaixacomptador/all";

        public static string GetById(int id) => $"api/motiusbaixacomptador/{id}";
        public static string GetByText(string text) => $"api/motiusbaixacomptador/search/{text}";
    }
}
