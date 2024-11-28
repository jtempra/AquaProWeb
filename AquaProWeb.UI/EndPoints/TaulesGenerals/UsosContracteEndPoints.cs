namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class UsosContracteEndPoints
    {
        public const string Add = "api/usoscontracte/add";
        public const string Update = "api/usoscontracte/update";
        public const string Delete = "api/usoscontracte";
        public const string GetAll = "api/usoscontracte/all";

        public static string GetById(int id) => $"api/usoscontracte/{id}";
        public static string GetByText(string text) => $"api/usoscontracte/search/{text}";
    }
}
