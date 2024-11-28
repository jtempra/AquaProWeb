namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class FamiliesConcepteFacturaEndPoints
    {
        public const string Add = "api/familiesconceptefactura/add";
        public const string Update = "api/familiesconceptefactura/update";
        public const string Delete = "api/familiesconceptefactura";
        public const string GetAll = "api/familiesconceptefactura/all";

        public static string GetById(int id) => $"api/familiesconceptefactura/{id}";
        public static string GetByText(string text) => $"api/familiesconceptefactura/search/{text}";
    }
}
