namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class RutesLecturaEndPoints
    {
        public const string Add = "api/ruteslectura/add";
        public const string Update = "api/ruteslectura/update";
        public const string Delete = "api/ruteslectura";
        public const string GetAll = "api/ruteslectura/all";

        public static string GetById(int id) => $"api/ruteslectura/{id}:int";
        public static string GetByText(string text) => $"api/ruteslectura/search/{text}:string";
    }
}
