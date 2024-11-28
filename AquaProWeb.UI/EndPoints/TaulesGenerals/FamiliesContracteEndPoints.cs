namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class FamiliesContracteEndPoints
    {
        public const string Add = "api/familiescontracte/add";
        public const string Update = "api/familiescontracte/update";
        public const string Delete = "api/familiescontracte";
        public const string GetAll = "api/familiescontracte/all";

        public static string GetById(int id) => $"api/familiescontracte/{id}";
        public static string GetByText(string text) => $"api/familiescontracte/search/{text}";
    }
}
