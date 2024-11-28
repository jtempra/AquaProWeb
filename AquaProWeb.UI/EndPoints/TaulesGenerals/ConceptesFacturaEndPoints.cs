namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ConceptesFacturaEndPoints
    {
        public const string Add = "api/conceptesfactura/add";
        public const string Update = "api/conceptesfactura/update";
        public const string Delete = "api/conceptesfactura";
        public const string GetAll = "api/conceptesfactura/all";

        public static string GetById(int id) => $"api/conceptesfactura/{id}";
        public static string GetByText(string text) => $"api/conceptesfactura/search/{text}";
    }
}
