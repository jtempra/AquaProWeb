namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class PoblacionsEndPoints
    {
        public const string Add = "api/poblacions/add";
        public const string Update = "api/poblacions/update";
        public const string Delete = "api/poblacions";
        public const string GetAll = "api/poblacions/all";

        public static string GetById(int id) => $"api/poblacions/{id}:int";
        public static string GetByText(string text) => $"api/poblacions/search/{text}:string";
    }
}
