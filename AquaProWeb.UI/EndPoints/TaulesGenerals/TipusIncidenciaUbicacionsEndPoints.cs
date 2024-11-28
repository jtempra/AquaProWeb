namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusIncidenciaUbicacionsEndPoints
    {
        public const string Add = "api/tipusincidenciaubicacions/add";
        public const string Update = "api/tipusincidenciaubicacions/update";
        public const string Delete = "api/tipusincidenciaubicacions";
        public const string GetAll = "api/tipusincidenciaubicacions/all";

        public static string GetById(int id) => $"api/tipusincidenciaubicacions/{id}";
        public static string GetByText(string text) => $"api/tipusincidenciaubicacions/search/{text}";
    }
}
