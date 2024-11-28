namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class SituacionsRebutEndPoints
    {
        public const string Add = "api/situacionsrebut/add";
        public const string Update = "api/situacionsrebut/update";
        public const string Delete = "api/situacionsrebut";
        public const string GetAll = "api/situacionsrebut/all";

        public static string GetById(int id) => $"api/situacionsrebut/{id}";
        public static string GetByText(string text) => $"api/situacionsrebut/search/{text}";
    }
}
