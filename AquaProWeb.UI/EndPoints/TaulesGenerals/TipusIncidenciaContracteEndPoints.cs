namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class TipusIncidenciaContracteEndPoints
    {
        public const string Add = "api/tipusincidenciacontracte/add";
        public const string Update = "api/tipusincidenciacontracte/update";
        public const string Delete = "api/tipusincidenciacontracte";
        public const string GetAll = "api/tipusincidenciacontracte/all";

        public static string GetById(int id) => $"api/tipusincidenciacontracte/{id}";
        public static string GetByText(string text) => $"api/tipusincidenciacontracte/search/{text}";
    }
}
