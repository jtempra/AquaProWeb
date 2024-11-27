namespace AquaProWeb.UI.EndPoints
{
    public class ZonesCarrerEndPoints
    {
        public const string Add = "api/zonescarrers/add";
        public const string Update = "api/zonescarrers/update";
        public const string Delete = "api/zonescarrers";
        public const string GetAll = "api/zonescarrers/all";

        public static string GetById(int id) => $"api/zonescarrers/{id}:int";
        public static string GetByText(string text) => $"api/zonescarrers/search/{text}:string";
    }
}
