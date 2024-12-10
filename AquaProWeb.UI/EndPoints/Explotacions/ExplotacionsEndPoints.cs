namespace AquaProWeb.UI.EndPoints.Explotacions
{
    public static class ExplotacionsEndPoints
    {
        public const string Add = "api/explotacions/add";
        public const string Update = "api/explotacions/update";
        public const string Delete = "api/explotacions";
        public const string GetAll = "api/explotacions/all";

        public static string GetById(int id) => $"api/explotacions/{id}:int";
    }
}
