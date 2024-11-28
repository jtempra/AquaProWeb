namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusDocumentEndPoints
    {
        public const string Add = "api/tipusdocument/add";
        public const string Update = "api/tipusdocument/update";
        public const string Delete = "api/tipusdocument";
        public const string GetAll = "api/tipusdocument/all";

        public static string GetById(int id) => $"api/tipusdocument/{id}";
        public static string GetByText(string text) => $"api/tipusdocument/search/{text}";
    }
}
