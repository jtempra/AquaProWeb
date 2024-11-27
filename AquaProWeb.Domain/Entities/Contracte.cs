using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;

namespace AquaProWeb.Domain.Entities
{
    public class Contracte : BaseEntity
    {

        public int UbicacioId
        {
            get; set;
        }
        public virtual Ubicacio Ubicacio
        {
            get; set;
        }
        public TipusContracte Tipus
        {
            get; set;
        }
        public DateTime DataSolicitud
        {
            get; set;
        }
        public DateTime DataAlta
        {
            get; set;
        }
        public DateTime DataAltaFacturacio
        {
            get; set;
        }
        public DateTime? DataBaixa
        {
            get; set;
        }
        public DateTime? DataVenciment
        {
            get; set;
        }
        public int DuracioContracte { get; set; } = 0;
        public double VolumContractat
        {
            get; set;
        }
        public double PressioContractada
        {
            get; set;
        }
        public double ConsumMinim
        {
            get; set;
        }
        public double ConsumMaxim
        {
            get; set;
        }
        public double ConsumPromig
        {
            get; set;
        }
        public double ConsumCompensar
        {
            get; set;
        }
        public string? Butlleti
        {
            get; set;
        }
        public DateTime? DataButlleti
        {
            get; set;
        }
        public string? Referencia
        {
            get; set;
        }
        public DateTime? DataReferencia
        {
            get; set;
        }
        public string? Cedula
        {
            get; set;
        }
        public DateTime? DataCedula
        {
            get; set;
        }
        public PeriodeFacturacio PeriodeFacturacio
        {
            get; set;
        }
        public bool Facturable
        {
            get; set;
        }
        public bool SubministramentTallat
        {
            get; set;
        }
        public DateTime? DataTall
        {
            get; set;
        }
        public bool Tallable
        {
            get; set;
        }
        public bool Empleat
        {
            get; set;
        }
        public int FamiliaId
        {
            get; set;
        }
        public FamiliaContracte Familia
        {
            get; set;
        }
        public int UsId
        {
            get; set;
        }
        public UsContracte Us
        {
            get; set;
        }
        public Idioma Idioma
        {
            get; set;
        }
        public ICollection<AnotacioContracte> Anotacions
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public int Revisio
        {
            get; set;
        }
        public TipusSubministrament TipusSubministrament
        {
            get; set;
        }
        public PropietatComptador PropietatComptador
        {
            get; set;
        }

        public int ZonaFacturacioId
        {
            get; set;
        }
        public ZonaFacturacio ZonaFacturacio
        {
            get; set;
        }
        public ICollection<ContacteContracte> ContactesContracte { get; set; } = new List<ContacteContracte>();
        public ICollection<TitularContracte> TitularsContracte { get; set; } = new List<TitularContracte>();
        public ICollection<TitularCompteContracte> TitularsCompteContracte { get; set; } = new List<TitularCompteContracte>();
        public ICollection<IncidenciaContracte> IncidenciesContracte { get; set; } = new List<IncidenciaContracte>();
        public ICollection<Document> DocumentsContracte { get; set; } = new List<Document>();
        public ICollection<ContracteTarifaServei> TarifesServeisContracte { get; set; } = new List<ContracteTarifaServei>();
        public virtual ICollection<OrdreTreball> OrdresTreball
        {
            get; set;
        }
    }
}
