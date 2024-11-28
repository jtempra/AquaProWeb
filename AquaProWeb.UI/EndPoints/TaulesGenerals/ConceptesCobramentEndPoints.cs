namespace AquaProWeb.UI.EndPoints.TaulesGenerals
{
    public class ConceptesCobramentEndPoints
    {
        public const string Add = "api/conceptescobrament/add";
        public const string Update = "api/conceptescobrament/update";
        public const string Delete = "api/conceptescobrament";
        public const string GetAll = "api/conceptescobrament/all";

        public static string GetById(int id) => $"api/conceptescobrament/{id}";
        public static string GetByText(string text) => $"api/conceptescobrament/search/{text}";
    }
}
