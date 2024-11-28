namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class SeriesRebutEndPoints
    {
        public const string Add = "api/seriesrebut/add";
        public const string Update = "api/seriesrebut/update";
        public const string Delete = "api/seriesrebut";
        public const string GetAll = "api/seriesrebut/all";

        public static string GetById(int id) => $"api/seriesrebut/{id}";
        public static string GetByText(string text) => $"api/seriesrebut/search/{text}";
    }
}
