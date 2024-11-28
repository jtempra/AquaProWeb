namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class SituacionsFacturaEndPoints
    {
        public const string Add = "api/situacionsfactura/add";
        public const string Update = "api/situacionsfactura/update";
        public const string Delete = "api/situacionsfactura";
        public const string GetAll = "api/situacionsfactura/all";

        public static string GetById(int id) => $"api/situacionsfactura/{id}";
        public static string GetByText(string text) => $"api/situacionsfactura/search/{text}";
    }
}
