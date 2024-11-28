namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class SeriesFacturaEndPoints
    {
        public const string Add = "api/seriesfactura/add";
        public const string Update = "api/seriesfactura/update";
        public const string Delete = "api/seriesfactura";
        public const string GetAll = "api/seriesfactura/all";

        public static string GetById(int id) => $"api/seriesfactura/{id}";
        public static string GetByText(string text) => $"api/seriesfactura/search/{text}";
    }
}
