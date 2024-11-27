using AquaProWeb.Domain.Contracts;
using AquaProWeb.Common.Enums;
using NetTopologySuite.Geometries;


namespace AquaProWeb.Domain.Entities
{
    public class OrdreTreball : BaseEntity
    {
        public int? ContracteId
        {
            get; set;
        }
        public Contracte Contracte
        {
            get; set;
        }
        public int? ClientId
        {
            get; set;
        }
        public Client Client
        {
            get; set;
        }
        public int TipusOrdreTreballId
        {
            get; set;
        }
        public TipusOrdreTreball Tipus
        {
            get; set;
        }
        public TipusOrigenOrdreTreball Origen
        {
            get; set;
        }
        public DateTime DataCreacio
        {
            get; set;
        }
        public DateTime DataSituacio
        {
            get; set;
        }
        public int CreadorId
        {
            get; set;
        }
        public Operari Creador
        {
            get; set;
        }
        public int ResponsableId
        {
            get; set;
        }
        public Operari Responsable
        {
            get; set;
        }
        public ICollection<OperariOrdre> OperarisOrdre
        {
            get; set;
        }
        public SituacioOT Situacio
        {
            get; set;
        }
        public int SituacioAdministrativaOTId
        {
            get; set;
        }
        public SituacioAdministrativaOT SituacioAdministrativa
        {
            get; set;
        }
        public string Descripcio
        {
            get; set;
        }
        public string Solucio
        {
            get; set;
        }

        public Boolean Facturable { get; set; } = false;
        public Boolean TallSubministrament
        {
            get; set;
        }
        public ICollection<Factura> Factures
        {
            get; set;
        }
        public string Ubicacio
        {
            get; set;
        }
        public int ZonaOrdreTreballId
        {
            get; set;
        }
        public ZonaOrdreTreball Zona
        {
            get; set;
        }
        public PrioritatOT Prioritat { get; set; } = PrioritatOT.Normal;
        public Point? Geolocalitzacio
        {
            get; set;
        }
        public Boolean Recurrent { get; set; } = false;
        public Boolean EnviadaApp { get; set; } = false;
        public ICollection<AnotacioOrdreTreball> Anotacions
        {
            get; set;
        }
        public ICollection<DetallOrdreTreball> DetallsOrdreTreball
        {
            get; set;
        }

    }
}
