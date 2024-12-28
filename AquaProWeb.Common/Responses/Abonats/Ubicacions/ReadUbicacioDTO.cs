using AquaProWeb.Common.Responses.Abonats.Escomeses;
using AquaProWeb.Common.Responses.TaulesGenerals.Carrers;
using AquaProWeb.Common.Responses.TaulesGenerals.Poblacions;
using AquaProWeb.Common.Responses.TaulesGenerals.RutaLectura;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusUbicacions;
using AquaProWeb.Common.Responses.TaulesGenerals.ZonesUbicacions;

namespace AquaProWeb.Common.Responses.Abonats.Ubicacions
{
    public class ReadUbicacioDTO
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
        public ReadTipusUbicacioDTO TipusUbicacio { get; set; }
        public int ZonaUbicacioId { get; set; }
        public ReadZonaUbicacioDTO ZonaUbicacio { get; set; }
        public int PoblacioId { get; set; }
        public ReadPoblacioDTO Poblacio { get; set; }
        public int CarrerId { get; set; }
        public ReadCarrerDTO Carrer { get; set; }
        public int EscomesaId { get; set; }
        public ReadEscomesaDTO Escomesa { get; set; }
        public string? SituacioComptador { get; set; }
        public int RutaLecturaId { get; set; }
        public ReadRutaLecturaDTO RutaLectura { get; set; }
        public int OrdreRutaLectura { get; set; }
    }
}
