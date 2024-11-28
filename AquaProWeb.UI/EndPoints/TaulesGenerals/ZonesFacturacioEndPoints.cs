namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ZonesFacturacioEndPoints
    {
        public const string Add = "api/zonesfacturacio/add";
        public const string Update = "api/zonesfacturacio/update";
        public const string Delete = "api/zonesfacturacio";
        public const string GetAll = "api/zonesfacturacio/all";

        public static string GetById(int id) => $"api/zonesfacturacio/{id}";
        public static string GetByText(string text) => $"api/zonesfacturacio/search/{text}";
    }
}
