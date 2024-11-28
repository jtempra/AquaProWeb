namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusIncidenciaLecturaEndPoints
    {
        public const string Add = "api/tipusincidencialectura/add";
        public const string Update = "api/tipusincidencialectura/update";
        public const string Delete = "api/tipusincidencialectura";
        public const string GetAll = "api/tipusincidencialectura/all";

        public static string GetById(int id) => $"api/tipusincidencialectura/{id}";
        public static string GetByText(string text) => $"api/tipusincidencialectura/search/{text}";
    }
}
