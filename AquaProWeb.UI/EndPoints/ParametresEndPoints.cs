namespace AquaProWeb.UI.EndPoints
{
    public static class ParametresEndPoints
    {
        public const string Add = "api/parametres/add";
        public const string Update = "api/parametres/update";
        public const string Delete = "api/parametres";
        public const string GetAll = "api/parametres/all";

        public static string GetById(int id) => $"api/parametres/{id}:int";
    }
}
