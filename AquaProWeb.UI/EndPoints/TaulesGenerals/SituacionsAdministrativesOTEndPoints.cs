namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class SituacionsAdministrativesOTEndPoints
    {
        public const string Add = "api/situacionsadminot/add";
        public const string Update = "api/situacionsadminot/update";
        public const string Delete = "api/situacionsadminot";
        public const string GetAll = "api/situacionsadminot/all";

        public static string GetById(int id) => $"api/situacionsadminot/{id}";
        public static string GetByText(string text) => $"api/situacionsadminot/search/{text}";
    }
}
