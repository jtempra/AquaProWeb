using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Nom
        {
            get; set;
        }
        public string PrimerCognom
        {
            get; set;
        }
        public string SegonCognom
        {
            get; set;
        }
        public string NomSencer => Nom + " " + PrimerCognom + " " + SegonCognom;
        public TipusContacte TipusContacte
        {
            get; set;
        }
        public int TipusClientId
        {
            get; set;
        }
        public virtual TipusClient TipusClient
        {
            get; set;
        }
        public TipusDocumentIdentificacio TipusDocumentIdentificacio
        {
            get; set;
        }
        public string DocumentIdentificacio
        {
            get; set;
        }
        public int TipusViaId
        {
            get; set;
        }
        public virtual TipusVia TipusVia
        {
            get; set;
        }
        public string Adressa
        {
            get; set;
        }
        public string CodiPostal
        {
            get; set;
        }
        public string Poblacio
        {
            get; set;
        }
        public string Provincia
        {
            get; set;
        }
        public int PaisId
        {
            get; set;
        }
        public virtual Pais Pais
        {
            get; set;
        }
        public string? ResteAdressa
        {
            get; set;
        }
        public string Telefon1
        {
            get; set;
        }
        public string? Telefon2
        {
            get; set;
        }
        public string? Telefon3
        {
            get; set;
        }
        public string Mobil1
        {
            get; set;
        }
        public string? Mobil2
        {
            get; set;
        }
        public string? Mobil3
        {
            get; set;
        }
        public string EMail1
        {
            get; set;
        }
        public string? EMail2
        {
            get; set;
        }
        public string? EMail3
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public string? IBAN
        {
            get; set;
        }
        public DateTime DataAlta
        {
            get; set;
        }
        public DateTime? DataBaixa
        {
            get; set;
        }
        public bool RebCartes
        {
            get; set;
        }
        public bool RebFactures
        {
            get; set;
        }
        public bool RebRebuts
        {
            get; set;
        }
        //public virtual ICollection<TitularContracte> TitularsContracte
        //{
        //    get; set;
        //}
        //public virtual ICollection<TitularCompteContracte> TitularsComptesContracte
        //{
        //    get; set;
        //}
        //public virtual ICollection<ContacteContracte> ContactesContracte
        //{
        //    get; set;
        //}
        public virtual ICollection<IncidenciaClient> IncidenciesClient
        {
            get; set;
        }
        public virtual ICollection<OrdreTreball> OrdresTreball
        {
            get; set;
        }

    }
}
