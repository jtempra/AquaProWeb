namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class RutasLecturaEndPoints
    {
        public const string Add = "api/rutaslectura/add";
        public const string Update = "api/rutaslectura/update";
        public const string Delete = "api/rutaslectura";
        public const string GetAll = "api/rutaslectura/all";

        public static string GetById(int id) => $"api/rutaslectura/{id}:int";
        public static string GetByText(string text) => $"api/rutaslectura/search/{text}:string";
    }
}
