namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public static class ComptesRemesaBancEndPoints
    {
        public const string Add = "api/comptesremesabanc/add";
        public const string Update = "api/comptesremesabanc/update";
        public const string Delete = "api/carcomptesremesabancrers";
        public const string GetAll = "api/comptesremesabanc/all";

        public static string GetById(int id) => $"api/comptesremesabanc/{id}";
        public static string GetByText(string text) => $"api/comptesremesabanc/search/{text}";
    }
}
