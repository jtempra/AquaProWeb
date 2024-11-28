namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ComptesTransferenciaClientEndPoints
    {
        public const string Add = "api/comptestransferenciaclient/add";
        public const string Update = "api/comptestransferenciaclient/update";
        public const string Delete = "api/comptestransferenciaclient";
        public const string GetAll = "api/comptestransferenciaclient/all";

        public static string GetById(int id) => $"api/comptestransferenciaclient/{id}";
        public static string GetByText(string text) => $"api/comptestransferenciaclient/search/{text}";
    }
}
