namespace AquaProWeb.Common.Responses.Abonats.Ubicacions
{
    public class ListUbicacioDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string? Bloc { get; set; }
        public string? Escala { get; set; }
        public string? Pis { get; set; }
        public string? Porta { get; set; }
        public string? ResteAdreça { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string? Localitzacio { get; set; }
        public string? ReferenciaCatastral { get; set; }
        public string? Observacions { get; set; }
        public DateTime? DataAlta { get; set; }
        public DateTime? DataBaixa { get; set; }
        public string TipusUbicacio { get; set; }
        public string ZonaUbicacio { get; set; }
        public string Poblacio { get; set; }
        public string Carrer { get; set; }
        public string Escomesa { get; set; }
        public string? SituacioComptador { get; set; }
        public string RutaLectura { get; set; }
        public int OrdreRutaLectura { get; set; }
    }
}
