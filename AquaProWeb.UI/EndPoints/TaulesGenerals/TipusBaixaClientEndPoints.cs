namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusBaixaClientEndPoints
    {
        public const string Add = "api/tipusbaixaclient/add";
        public const string Update = "api/tipusbaixaclient/update";
        public const string Delete = "api/tipusbaixaclient";
        public const string GetAll = "api/tipusbaixaclient/all";

        public static string GetById(int id) => $"api/tipusbaixaclient/{id}";
        public static string GetByText(string text) => $"api/tipusbaixaclient/search/{text}";
    }
}
