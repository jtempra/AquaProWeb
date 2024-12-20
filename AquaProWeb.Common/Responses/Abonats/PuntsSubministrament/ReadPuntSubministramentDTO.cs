using System.Drawing;

namespace AquaProWeb.Common.Responses.Abonats.PuntsSubministrament
{
    public class ReadPuntSubministramentDTO
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string? Bloc { get; set; }
        public string? Escala { get; set; }
        public string? Pis { get; set; }
        public string? Porta { get; set; }
        public string? ResteAdreça { get; set; }
        public Point? PosicioGeografica { get; set; }
        public string? Localitzacio { get; set; }
        public string? ReferenciaCatastral { get; set; }
        public string? Observacions { get; set; }
        public DateTime? DataAlta { get; set; }
        public DateTime? DataBaixa { get; set; }
        public int TipusUbicacio { get; set; }
        public int ZonaUbicacio { get; set; }
        public int Poblacio { get; set; }
        public int Carrer { get; set; }
        public int Escomesa { get; set; }
        public string? SituacioComptador { get; set; }
        public int RutaLectura { get; set; }
        public int OrdreRutaLectura { get; set; }
    }
}
