namespace AquaProWeb.UI.EndPoints
{
    public class TipusViaEndPoints
    {
        public const string Add = "api/tipusvia/add";
        public const string Update = "api/tipusvia/update";
        public const string Delete = "api/tipusvia";
        public const string GetAll = "api/tipusvia/all";

        public static string GetById(int id) => $"api/tipusvia/{id}:int";
    }
}
