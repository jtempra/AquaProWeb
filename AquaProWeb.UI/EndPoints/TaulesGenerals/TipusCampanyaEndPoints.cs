namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusCampanyaEndPoints
    {
        public const string Add = "api/tipuscampanya/add";
        public const string Update = "api/tipuscampanya/update";
        public const string Delete = "api/tipuscampanya";
        public const string GetAll = "api/tipuscampanya/all";

        public static string GetById(int id) => $"api/tipuscampanya/{id}";
        public static string GetByText(string text) => $"api/tipuscampanya/search/{text}";
    }
}
