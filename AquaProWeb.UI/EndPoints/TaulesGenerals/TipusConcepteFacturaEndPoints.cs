namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusConcepteFacturaEndPoints
    {
        public const string Add = "api/tipusclient/add";
        public const string Update = "api/tipusclient/update";
        public const string Delete = "api/tipusclient";
        public const string GetAll = "api/tipusclient/all";

        public static string GetById(int id) => $"api/tipusclient/{id}";
        public static string GetByText(string text) => $"api/tipusclient/search/{text}";
    }
}
