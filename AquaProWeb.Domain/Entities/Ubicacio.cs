using AquaProWeb.Domain.Contracts;
using NetTopologySuite.Geometries;


namespace AquaProWeb.Domain.Entities
{
    public class Ubicacio : BaseEntity
    {
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
        public int TipusUbicacioId { get; set; }
        public TipusUbicacio Tipus { get; set; }
        public int ZonaUbicacioId { get; set; }
        public ZonaUbicacio Zona { get; set; }
        public int PoblacioId { get; set; }
        public Poblacio Poblacio { get; set; }
        public int CarrerId { get; set; }
        public Carrer Carrer { get; set; }
        public int EscomesaId { get; set; }
        public Escomesa Escomesa { get; set; }
        public ICollection<Contracte> Contractes { get; set; }
        public ICollection<ComptadorUbicacio> ComptadorUbicacions { get; set; }
        public string? SituacioComptador { get; set; }
        public RutaLectura RutaLectura { get; set; }
        public int RutaLecturaId { get; set; }
        public int OrdreRutaLectura { get; set; }
    }
}
