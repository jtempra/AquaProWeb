namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class CarrersEndPoints
    {
        public const string Add = "api/carrers/add";
        public const string Update = "api/carrers/update";
        public const string Delete = "api/carrers";
        public const string GetAll = "api/Carrers/all";

        public static string GetById(int id) => $"api/carrers/{id}";
        public static string GetByText(string text) => $"api/carrers/search/{text}";
    }
}
