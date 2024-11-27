using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Domain.Entities
{
    public class Campanya : BaseEntity
    {
        public string Nom
        {
            get; set;
        }
        public int TipusCampanyaId
        {
            get; set;
        }
        public TipusCampanya TipusCampanya
        {
            get; set;
        }
        public DateTime DataCampanya
        {
            get; set;
        }
        public string? Descripcio
        {
            get; set;
        }
        public string? Observacions
        {
            get; set;
        }
        public DateTime? DataInici
        {
            get; set;
        }
        public DateTime? DataFinal
        {
            get; set;
        }

        //public List<RebutCampanya> RebutsCampanya { get; set; } = new List<RebutCampanya>();
        //public List<FacturaCampanya> FacturesCampanya { get; set; } = new List<FacturaCampanya>();
        public List<DocumentCampanya> DocumentsCampanya { get; set; } = new List<DocumentCampanya>();
        public List<OrdreTreball> OrdresTreballCampanya { get; set; } = new List<OrdreTreball>();
        public List<CartaCampanya> CartesCampanya { get; set; } = new List<CartaCampanya>();
        public List<AnotacioCampanya> AnotacionsCampanya { get; set; } = new List<AnotacioCampanya>();
    }
}
