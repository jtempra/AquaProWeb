namespace AquaProWeb.UI.EndPoints
{
    public class CanalsCobramentEndPoints
    {
        public const string Add = "api/canalscobrament/add";
        public const string Update = "api/canalscobrament/update";
        public const string Delete = "api/canalscobrament";
        public const string GetAll = "api/canalscobrament/all";

        public static string GetById(int id) => $"api/canalscobrament/{id}:int";
    }
}
