namespace AquaProWeb.Common.Requests.Abonats.PuntsSubministrament
{
    public class SaveUbicacioDTO
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
        public int TipusUbicacioId { get; set; }
        public int ZonaUbicacioId { get; set; }
        public int PoblacioId { get; set; }
        public int CarrerId { get; set; }
        public int EscomesaId { get; set; }
        public string? SituacioComptador { get; set; }
        public int RutaLecturaId { get; set; }
        public int OrdreRutaLectura { get; set; }
    }
}
