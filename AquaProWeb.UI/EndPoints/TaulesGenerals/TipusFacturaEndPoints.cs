namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusFacturaEndPoints
    {
        public const string Add = "api/tipusfactura/add";
        public const string Update = "api/tipusfactura/update";
        public const string Delete = "api/tipusfactura";
        public const string GetAll = "api/tipusfactura/all";

        public static string GetById(int id) => $"api/tipusfactura/{id}";
        public static string GetByText(string text) => $"api/tipusfactura/search/{text}";
    }
}
