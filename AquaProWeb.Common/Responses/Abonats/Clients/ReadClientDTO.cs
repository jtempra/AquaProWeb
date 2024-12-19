using AquaProWeb.Common.Enums;
using AquaProWeb.Common.Responses.TaulesGenerals.Paisos;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusClients;
using AquaProWeb.Common.Responses.TaulesGenerals.TipusVies;

namespace AquaProWeb.Common.Responses.Abonats.Clients
{
    public class ReadClientDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string PrimerCognom { get; set; }
        public string SegonCognom { get; set; }
        public ReadTipusClientDTO TipusClient { get; set; }
        public TipusDocumentIdentificacio TipusDocumentIdentificacio { get; set; }
        public string DocumentIdentificacio { get; set; }
        public ReadTipusViaDTO TipusVia { get; set; }
        public string Adressa { get; set; }
        public string CodiPostal { get; set; }
        public string Poblacio { get; set; }
        public string Provincia { get; set; }
        public ReadPaisDTO Pais { get; set; }
        public string? ResteAdressa { get; set; }
        public string Telefon1 { get; set; }
        public string? Telefon2 { get; set; }
        public string? Telefon3 { get; set; }
        public string Mobil1 { get; set; }
        public string? Mobil2 { get; set; }
        public string? Mobil3 { get; set; }
        public string EMail1 { get; set; }
        public string? EMail2 { get; set; }
        public string? EMail3 { get; set; }
        public string? Observacions { get; set; }
        public string? IBAN { get; set; }
        public DateTime? DataAlta { get; set; }
        public DateTime? DataBaixa { get; set; }
        public bool RebCartes { get; set; }
        public bool RebFactures { get; set; }
        public bool RebRebuts { get; set; }
    }
}
