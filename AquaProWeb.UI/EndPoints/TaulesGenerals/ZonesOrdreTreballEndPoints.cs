namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ZonesOrdreTreballEndPoints
    {
        public const string Add = "api/zonesot/add";
        public const string Update = "api/zonesot/update";
        public const string Delete = "api/zonesot";
        public const string GetAll = "api/zonesot/all";

        public static string GetById(int id) => $"api/zonesot/{id}";
        public static string GetByText(string text) => $"api/zonesot/search/{text}";
    }
}
