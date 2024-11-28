namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ZonesUbicacioEndPoints
    {
        public const string Add = "api/zonesubicacio/add";
        public const string Update = "api/zonesubicacio/update";
        public const string Delete = "api/zonesubicacio";
        public const string GetAll = "api/zonesubicacio/all";

        public static string GetById(int id) => $"api/zonesubicacio/{id}";
        public static string GetByText(string text) => $"api/zonesubicacio/search/{text}";
    }
}
