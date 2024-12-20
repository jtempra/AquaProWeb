﻿namespace AquaProWeb.UI.EndPoints.Abonats
{
    public class PuntsSubministramentEndPoints
    {
        public const string Add = "api/ubicacions/add";
        public const string Update = "api/ubicacions/update";
        public const string Delete = "api/ubicacions";
        public const string GetAll = "api/ubicacions/all";

        public static string GetById(int id) => $"api/ubicacions/{id}";
        public static string GetByText(string text) => $"api/ubicacions/search/{text}";
    }
}
